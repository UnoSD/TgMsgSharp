using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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

        readonly ConcurrentBag<int> _processingOffsets;

        readonly object _locker = new object();

        public MessagesProcessor(TelegramClient client, int contactId)
        {
            _client = client;
            _contactId = contactId;
            _offset = 0;
            _limit = 100;
            _logger = LogManager.GetCurrentClassLogger();
            _processingOffsets = new ConcurrentBag<int>();
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

            var offset = GetNextUnprocessedOffset();

            do
            {
                messages = await GetMessages(offset, _limit);
            } while (messages == null && attempt++ <= MaximumAttempts);

            if (messages == null)
            {
                _logger.Error($"Cannot retrieve messages after {attempt} attempt. Offset: {_offset}");

                return new Message[0];
            }

            Interlocked.Add(ref _offset, messages.Count);
            
            _logger.Trace($"Messages loaded: #{_offset}#");

            return messages;
        }

        int GetNextUnprocessedOffset()
        {
            lock (_locker)
            {
                if (!_processingOffsets.Any())
                {
                    _processingOffsets.Add(_offset);

                    return _offset;
                }

                var next = _processingOffsets.Max() + _limit;

                _processingOffsets.Add(_offset);

                return next;
            }
        }

        async Task<IReadOnlyCollection<Message>> GetMessages(int offset, int limit) => await _client.GetMessagesHistoryForContact(_contactId, offset, limit);
    }
}