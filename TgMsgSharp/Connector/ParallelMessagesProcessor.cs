using System;
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
    public class ParallelMessagesProcessor
    {
        volatile int _workingMessagesProcessors;

        async Task<IReadOnlyCollection<TgMessage>> GetMessagesForContactId(TelegramClient _client, int contactId, Func<IEnumerable<Message>, IEnumerable<TgMessage>> map)
        {
            var returnValue = new ConcurrentBag<TgMessage>();

            var messagesProcessor = new MessagesProcessor(_client, contactId);

            var messagesReturned = new List<bool>();

            // As long as all the processors are returning messages, we assume there are still messages to process.
            while (messagesReturned.All(returned => returned))
            {
                if (_workingMessagesProcessors <= Environment.ProcessorCount)
                {
                    var processorsToStart = Environment.ProcessorCount - _workingMessagesProcessors;

                    var sdf = new List<Task>();

                    for (var index = 0; index <= processorsToStart; index++)
                        sdf.Add(ProcessMessages(messagesProcessor, returnValue, map).ContinueWith(task =>
                        {
                            Interlocked.Decrement(ref _workingMessagesProcessors);
                            messagesReturned.Add(task.Result);
                        }));

                    Interlocked.Add(ref _workingMessagesProcessors, processorsToStart);

                    //await Task.WhenAny(sdf);
                    await Task.WhenAll(sdf);
                }
            }

            return returnValue.ToArray();
        }

        async Task<bool> ProcessMessages(MessagesProcessor messagesProcessor, ConcurrentBag<TgMessage> returnValue, Func<IEnumerable<Message>, IEnumerable<TgMessage>> map)
        {
            try
            {
                var messages = await messagesProcessor.GetMessages();

                if (!messages.Any()) return false;

                var tgMessages = map(messages);

                foreach (var tgMessage in tgMessages)
                    returnValue.Add(tgMessage);
            }
            catch (Exception exception)
            {
                LogManager.GetCurrentClassLogger().Error(exception);

                return true;
            }

            return true;
        }
    }
}