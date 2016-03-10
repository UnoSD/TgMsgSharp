using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TLSharp.Core;
using TLSharp.Core.MTProto;

namespace TgMsgSharp.Connector
{
    public class MessagesProcessor
    {
        readonly TelegramClient _client;
        readonly int _contactId;
        readonly int _limit;
        int _offset;

        public MessagesProcessor(TelegramClient client, int contactId)
        {
            _client = client;
            _contactId = contactId;
            _offset = 0;
            _limit = 100;
        }

        public async Task<bool> GetMessagesAvailable()
        {
            var messages = await GetMessages(_offset, 1);

            return messages.Any();
        }

        public async Task<IReadOnlyCollection<Message>> GetMessages()
        {
            var messages = await GetMessages(_offset, _limit);

            _offset += messages.Count;

            return messages;
        }

        async Task<IReadOnlyCollection<Message>> GetMessages(int offset, int limit) => await _client.GetMessagesHistoryForContact(_contactId, offset, limit);
    }
}