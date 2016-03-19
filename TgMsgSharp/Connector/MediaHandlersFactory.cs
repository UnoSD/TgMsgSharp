using System;
using System.Collections.Generic;
using System.Linq;

namespace TgMsgSharp.Connector
{
    public class MediaHandlersFactory
    {
        readonly Lazy<IReadOnlyCollection<IMessageMediaHandler>> _handlers = new Lazy<IReadOnlyCollection<IMessageMediaHandler>>(CreateHandlers, true);

        static IReadOnlyCollection<IMessageMediaHandler> CreateHandlers()
        {
            return new IMessageMediaHandler[]
            {
                new MessageMediaPhotoHandler(),
                new MessageMediaAudioHandler(), 
                new EmptyMediaHandler()
            };
        }

        public IMessageMediaHandler GetMediaHandler(Type mediaType) => _handlers.Value.SingleOrDefault(handler => handler.TypeHandled == mediaType);
    }
}