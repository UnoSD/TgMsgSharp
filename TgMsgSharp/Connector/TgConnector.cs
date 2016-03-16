﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
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

        readonly Lazy<IReadOnlyCollection<TgContact>> _cachedContacts;
        readonly TgFileSettingsProvider _settingsProvider;
        readonly UserMapper _usersMapper;
        readonly TelegramClient _client;
        readonly string _number;

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

        public TgConnector(string number, int apiId, string apiHash, string settingsFilePath)
        {
            Tl.CreateCombinatorsLookupCache();

            _number = number;
            //var sessionStore = new SerializedSingleSessionStore(number, sessionData);
            _client = new TelegramClient(new FileSessionStore(), number, apiId, apiHash);
            _usersMapper = new UserMapper();
            _settingsProvider = new TgFileSettingsProvider(new FileInfo(settingsFilePath));
            _cachedContacts = new Lazy<IReadOnlyCollection<TgContact>>(() => GetContacts().Result);
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

            // Is it myself in the contact list?

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
            var returnValue = new ConcurrentBag<TgMessage>();

            var messagesProcessor = new MessagesProcessor(_client, contactId);

            for (var messages = await messagesProcessor.GetMessages(); ; messages.Any())
            {
                var tgMessages = MapMessages(messages);

                foreach(var tgMessage in tgMessages)
                    returnValue.Add(tgMessage);
            }
            
            return returnValue.ToArray();
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
                    Id = message.Id,
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

        public async Task<IReadOnlyCollection<TgContact>> GetContacts()
        {
            var contacts = await _client.GetContacts();

            var userContactConstructors = contacts.Users.OfType<UserContactConstructor>();

            return _usersMapper.Map(userContactConstructors).ToArray();
        }

        public IReadOnlyCollection<TgContact> GetCachedContacts() => _cachedContacts.Value;
    }
}
