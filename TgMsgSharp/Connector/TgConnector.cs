using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TLSharp.Core;
using TLSharp.Core.MTProto;

namespace TgMsgSharp.Connector
{
    public class TgConnector
    {
        public event EventHandler<ConnectorStatus> StatusChanged;

        readonly TelegramClient _client;
        readonly string _number;

        readonly IDictionary<string, int> _contactsCache;

        UserSelfConstructor _user;
        string _hash;
        int _retryGetMessages = 100;

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

        public TgConnector(string number, string sessionData, int apiId, string apiHash)
        {
            _number = number;
            //var sessionStore = new SerializedSingleSessionStore(number, sessionData);
            _client = new TelegramClient(new FileSessionStore(), number, apiId, apiHash);
            _contactsCache = new Dictionary<string, int>();
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

        async Task<IEnumerable<TgMessage>> GetMessagesForContactId(int contactId)
        {
            var returnValue = new List<TgMessage>();

            var offset = 0;
            List<Message> messages;

            while ((messages = await _client.GetMessagesHistoryForContact(contactId, offset, int.MaxValue))?.Count > 0 || _retryGetMessages > 0)
            {
                // Sometimes it returns null even if other messages are available, so we have to retry.
                if (messages == null)
                {
                    _retryGetMessages--;
                    continue;
                }

                //var firstOrDefault = messages.FirstOrDefault(message => returnValue.Select(tgMessage => tgMessage.MsgId).Contains(message.from_id));
                //if (firstOrDefault != null) // Message already in list.
                //Debugger.Break();

                returnValue.AddRange(MapMessages(messages));

                offset += messages.Count;

                // Not really elegant, but a way to deduce approximately wheather the messages are really over
                // as it will return null both when the fetching is failed and when the messages are over.
                // Waiting for a MessagesCount/NoMessagesResult from the TLSharp team...
                if (messages.Count < 100) break;
            }

            return returnValue;
        }

        static IEnumerable<TgMessage> MapMessages(IEnumerable<Message> messages)
        {
            return messages.OfType<MessageConstructor>().Select(message => new TgMessage
            {
                MsgType = message.id,
                SenderId = message.to_id,
                MsgId = message.from_id,
                Date = TgDateConverter.GetDateTime(message.date),
                Text = message.message,
                Unread = message.unread
            });

            //var photo = messageConstructor.media as MessageMediaPhotoConstructor;
            //var audio = messageConstructor.media as MessageMediaAudioConstructor;
            //var document = messageConstructor.media as MessageMediaDocumentConstructor;
            //var video = messageConstructor.media as MessageMediaVideoConstructor;
            //var contact = messageConstructor.media as MessageMediaContactConstructor;
            //var geo = messageConstructor.media as MessageMediaGeoConstructor;
            //var unsupportedMedia = messageConstructor.media as MessageMediaUnsupportedConstructor;
            //var empty = messageConstructor.media as MessageMediaEmptyConstructor;

            //if (photo != null)
            //{
            //    var photoConstructor = photo.photo as PhotoConstructor;

            //    if (photoConstructor == null) return;

            //    var fileInfo = new FileInfo(DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss-ffff"));

            //    using (var fileStream = fileInfo.OpenWrite())
            //        using(var binaryWriter = new BinaryWriter(fileStream))
            //            photo.Write(binaryWriter);
            //}
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
