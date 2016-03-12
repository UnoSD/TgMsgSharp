using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TgMsgSharp.Launcher;
using TLSharp.Core;
using TLSharp.Core.MTProto;

namespace TgMsgSharp.Connector
{
    public class TgConnector
    {
        public event EventHandler<ConnectorStatus> StatusChanged;

        readonly TgFileSettingsProvider _settingsProvider;
        readonly TelegramClient _client;
        readonly string _number;

        readonly IDictionary<string, int> _contactsCache;

        UserSelfConstructor _user;
        string _hash;

        ConnectorStatus _status = ConnectorStatus.NotConnected;
        
        public ConnectorStatus Status
        {
            get
            {
                return _status;
            }
            private set
            {
                if (_status != value)
                    StatusChanged?.Invoke(this, value);

                _status = value;
            }
        }

        public TgConnector(string number, string sessionData, int apiId, string apiHash, string settingsFilePath)
        {
            _number = number;
            //var sessionStore = new SerializedSingleSessionStore(number, sessionData);
            _client = new TelegramClient(new FileSessionStore(), number, apiId, apiHash);
            _contactsCache = new Dictionary<string, int>();

            _settingsProvider = new TgFileSettingsProvider(new FileInfo(settingsFilePath));
        }

        public async Task<ConnectorStatus> Connect()
        {
            Status = await ConnectOrSendCodeRequest();

            return Status;
        }

        async Task<ConnectorStatus> ConnectOrSendCodeRequest()
        {
            var success = await _client.Connect();

            if (!success) return ConnectorStatus.ClientError;

            try
            {
                var registered = await _client.IsPhoneRegistered(_number);

                if (!registered) return ConnectorStatus.NotRegistered;
            }
            catch
            {
                _hash = await _client.SendCodeRequest(_number);

                return ConnectorStatus.ValidationCodeNeeded;
            }

            return ConnectorStatus.Connected;
        }

        public async Task<ConnectorStatus> Authorize(int code)
        {
            _user = await _client.MakeAuth(_number, _hash, code.ToString()) as UserSelfConstructor;

            if (_user == null) return ConnectorStatus.ClientError;

            if (!_contactsCache.ContainsKey(_number))
                _contactsCache.Add(_number, _user.id);

            return ConnectorStatus.Connected;
        }

        public async Task<IEnumerable<TgMessage>> GetMessages(string number) => await GetMessages(number, string.Empty, string.Empty);

        public async Task<IEnumerable<TgMessage>> GetMessages(string number, string firstName, string lastName)
        {
            var contactId = await GetContactId(number, firstName, lastName);

            if (!contactId.HasValue) return new TgMessage[0];

            return await GetMessagesForContactId(contactId.Value);
        }

        async Task<IReadOnlyCollection<TgMessage>> GetMessagesForContactId(int contactId)
        {
            var returnValue = new List<TgMessage>();

            var messagesProcessor = new MessagesProcessor(_client, contactId);

            while (await messagesProcessor.GetMessagesAvailable())
            {
                var messages = await messagesProcessor.GetMessages();

                var tgMessages = MapMessages(messages);

                returnValue.AddRange(tgMessages);
            }
            
            return returnValue;
        }

        IEnumerable<TgMessage> MapMessages(IEnumerable<Message> messages)
        {
            return messages.OfType<MessageConstructor>().Select(message =>
            {
                var contentType = GetContentType(message.Media);

                return new TgMessage
                {
                    Flags = message.Flags.ToString(),
                    Sender = GetSender(message.FromId),
                    Receiver = GetReceiver(message.ToId),
                    MsgId = message.Id,
                    Date = TgDateConverter.GetDateTime(message.Date),
                    SmallImage = contentType.Item2,
                    Text = message.Message,
                    ContentType = contentType.Item1,
                    Unread = message.Unread,
                    Output = message.Output
                };
            });
        }

        static Tuple<string, Image> GetContentType(MessageMedia media)
        {
            if (media is MessageMediaEmptyConstructor) return new Tuple<string, Image>(media.ToString(), null);

            var photoMessage = media as MessageMediaPhotoConstructor;

            var cachedPhoto = (photoMessage?.photo as PhotoConstructor)?.sizes?.OfType<PhotoCachedSizeConstructor>().FirstOrDefault();

            Bitmap image = null;

            if (cachedPhoto != null)
                image = (Bitmap) new ImageConverter().ConvertFrom(cachedPhoto.bytes);

            return new Tuple<string, Image>(media.GetType().Name, image);
        }

        string GetSender(int sender) => GetUserFromId(sender);

        string GetReceiver(Peer receiver)
        {
            var peerUserConstructor = receiver as PeerUserConstructor;

            if(peerUserConstructor != null)
                return GetUserFromId(peerUserConstructor.user_id);

            var peerChatConstructor = receiver as PeerChatConstructor;

            return peerChatConstructor?.chat_id.ToString() ?? receiver.ToString();
        }

        string GetUserFromId(int userId)
        {
            var tgSettings = _settingsProvider.GetSettings();

            var singleOrDefault = tgSettings.Contacts.SingleOrDefault(contact => contact.Id == userId);

            if(singleOrDefault == null) Debugger.Break();

            return singleOrDefault?.FirstName ?? string.Empty;
        }

        async Task<int?> GetContactId(string number, string firstName, string lastName)
        {
            int contactId;

            if (_contactsCache.TryGetValue(number, out contactId)) return contactId;

            var newContactId = await TryGetContactId(number, firstName, lastName);

            if (!newContactId.HasValue) return null;

            contactId = newContactId.Value;

            _contactsCache.Add(number, contactId);

            return contactId;
        }

        async Task<int?> TryGetContactId(string number, string firstName, string lastName)
        {
            try
            {
                return await _client.ImportContactByPhoneNumber(number, firstName, lastName);
            }
            catch
            {
                return null;
            }
        }
    }
}
