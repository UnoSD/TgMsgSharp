using System;
using TLSharp.Core.MTProto;

namespace TgMsgSharp.Connector
{
    public class EmptyMediaHandler : IMessageMediaHandler
    {
        public Type TypeHandled => typeof(MessageMediaEmptyConstructor);

        public TgMedia Map(MessageMedia media) => null;
    }
}