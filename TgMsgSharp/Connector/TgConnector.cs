using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using NLog;
using TgMsgSharp.Launcher;
using TLSharp.Core;
using TLSharp.Core.MTProto;

namespace TgMsgSharp.Connector
{
    public class TgConnector
    {
        public event EventHandler<ConnectorStatus> StatusChanged;

        readonly Lazy<List<TgContact>> _cachedContacts;
        readonly UserMapper _usersMapper;
        readonly TelegramClient _client;
        readonly string _number;

        UserSelfConstructor _user;
        string _hash;

        ConnectorStatus _status = ConnectorStatus.NotConnected;
        readonly MediaHandlersFactory _mediaHandlersFactory;
        readonly Logger _logger;

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

        public TgConnector(string number, int apiId, string apiHash)
        {
            Tl.CreateCombinatorsLookupCache();

            _number = number;
            _logger = LogManager.GetCurrentClassLogger();
            //var sessionStore = new SerializedSingleSessionStore(number, sessionData);
            _client = new TelegramClient(new FileSessionStore(), number, apiId, apiHash);
            _usersMapper = new UserMapper();
            _cachedContacts = new Lazy<List<TgContact>>(() => Task.Run(GetContacts).Result);
            _mediaHandlersFactory = new MediaHandlersFactory();
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

            _cachedContacts.Value.Add(new TgContact
            {
                Id = _user.id,
                FirstName = _user.first_name,
                LastName = _user.last_name,
                Number = _user.phone
            });

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

            for (var messages = await messagesProcessor.GetMessages(); messages.Any(); messages = await messagesProcessor.GetMessages())
            {
                var tgMessages = MapMessages(messages);

                returnValue.AddRange(tgMessages);
            }

            return returnValue.ToArray();
        }

        IEnumerable<TgMessage> MapMessages(IEnumerable<Message> messages)
        {
            return messages.OfType<MessageConstructor>()
                           .AsParallel()
                           .Select(MapMessage);
        }

        TgMessage MapMessage(MessageConstructor message)
        {
            var handler = _mediaHandlersFactory.GetMediaHandler(message.Media.GetType());
            
            var tgMedia = handler?.Map(message.Media);
            
            //var image = (Bitmap)new ImageConverter().ConvertFrom(cachedPhoto.bytes);

            var tgMessage = new TgMessage
            {
                Flags = message.Flags.ToString(),
                Sender = GetSender(message.FromId),
                Receiver = GetReceiver(message.ToId),
                Id = message.Id,
                Date = TgDateConverter.GetDateTime(message.Date),
                Text = message.Message,
                ContentType = handler?.TypeHandled.Name,
                Unread = message.Unread,
                Output = message.Output
            };


            if (handler == null)
                _logger.Error($"Unable to find handler for media type: {message.Media.GetType()}");
            
            tgMessage.Media = tgMedia;

            return tgMessage;
        }

        string GetSender(int sender) => GetUserFromId(sender);

        string GetReceiver(Peer receiver)
        {
            var peerUserConstructor = receiver as PeerUserConstructor;

            if (peerUserConstructor != null)
                return GetUserFromId(peerUserConstructor.user_id);

            var peerChatConstructor = receiver as PeerChatConstructor;

            return peerChatConstructor?.chat_id.ToString() ?? receiver.ToString();
        }

        string GetUserFromId(int userId)
        {
            var singleOrDefault = this.GetCachedContacts().SingleOrDefault(contact => contact.Id == userId);

            return singleOrDefault?.FirstName ?? userId.ToString();
        }

        async Task<int?> GetContactId(string number, string firstName, string lastName)
        {
            var tgContact = _cachedContacts.Value.SingleOrDefault(contact => contact.Number == number);

            if (tgContact != null) return tgContact.Id;

            var newContactId = await TryGetContactId(number, firstName, lastName);

            return newContactId;
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

        public async Task<List<TgContact>> GetContacts()
        {
            var contacts = await _client.GetContacts();

            var userContactConstructors = contacts.Users.OfType<UserContactConstructor>();

            return _usersMapper.Map(userContactConstructors).ToList();
        }

        public IReadOnlyCollection<TgContact> GetCachedContacts() => _cachedContacts.Value;

        public async void DownloadImages(IEnumerable<TgMessage> messages, string selectedPath)
        {
            if (!Directory.Exists(selectedPath))
                return;

            var tgMedias = messages.Where(message => message.Media != null).Select(message => message.Media);

            foreach (var tgMedia in tgMedias)
            {
                var fileLocationConstructor = GetInputFileLocation(tgMedia.Location);

                var uploadFile = await _client.GetFile(fileLocationConstructor);

                var storageFileType = uploadFile.type;

                var fileName = $"{tgMedia.Id}.{GetExtension(storageFileType)}";

                var fullPath = Path.Combine(selectedPath, fileName);

                File.WriteAllBytes(fullPath, uploadFile.bytes);

                tgMedia.Path = Path.Combine("files", fileName); // Get relative to db file.
            }
        }

        //public static string MakeRelative(string sourcePath, string referencePath)
        //{
        //    var sourceUri = new Uri(sourcePath);
        //    var referenceUri = new Uri(referencePath);

        //    return referenceUri.MakeRelativeUri(sourceUri).ToString();
        //}

        InputFileLocation GetInputFileLocation(TgLocation location)
        {
            switch (location.InputType.Name)
            {
                case nameof(InputAudioFileLocationConstructor):
                    return new InputAudioFileLocationConstructor
                    {
                        id = location.Id,
                        access_hash = location.AccessHash
                    };
                case nameof(InputFileLocationConstructor):
                    return new InputFileLocationConstructor
                    {
                        volume_id = location.VolumeId,
                        local_id = location.LocalId,
                        secret = location.Secret
                    };
                default:
                    throw new Exception();
            }
        }

        static string GetExtension(storage_FileType storageFileType)
        {
            var typeName = storageFileType.GetType().Name;

            typeName = typeName.Substring("Storage_file".Length);

            typeName = typeName.Substring(0, typeName.Length - "Constructor".Length);

            //if(typeName.ToLowerInvariant() == "partial" || typeName.ToLowerInvariant() == "unknown")

            return typeName.ToLowerInvariant();
        }
    }
}
