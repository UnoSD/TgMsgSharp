using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NLog;
using TLSharp.Core;
using TLSharp.Core.MTProto;

namespace TgMsgSharp.Connector
{
    public class MessagesProcessor
    {
        const int MaximumAttempts = 10;

        readonly TelegramClient _client;
        readonly Logger _logger;
        readonly int _contactId;
        readonly int _limit;
        int _offset;
        
        public MessagesProcessor(TelegramClient client, int contactId)
        {
            _client = client;
            _contactId = contactId;
            _offset = 0;
            _limit = 100;
            _logger = LogManager.GetCurrentClassLogger();
        }

        public async Task<bool> GetMessagesAvailable()
        {
            IReadOnlyCollection<Message> messages = null;
            var attempt = 0;

            do
                messages = await GetMessages(_offset, 1);
            while (messages == null && attempt++ <= MaximumAttempts);

            if (messages != null) return messages.Any();

            _logger.Error($"Cannot retrieve messages after {attempt} attempt. Offset: {_offset}");

            return false;
        }

        public async Task<IReadOnlyCollection<Message>> GetMessages()
        {
            IReadOnlyCollection<Message> messages = null;
            var attempt = 0;

            do
            {
                messages = await GetMessages(_offset, _limit);
            } while (messages == null && attempt++ <= MaximumAttempts);

            if (messages == null)
            {
                _logger.Error($"Cannot retrieve messages after {attempt} attempt. Offset: {_offset}");

                return new Message[0];
            }

            _offset += messages.Count;

            return messages;
        }

        async Task<IReadOnlyCollection<Message>> GetMessages(int offset, int limit) => await _client.GetMessagesHistoryForContact(_contactId, offset, limit);
    }
}