using System;
using TLSharp.Core.MTProto;

namespace TgMsgSharp.Connector
{
    public interface IMessageMediaHandler
    {
        Type TypeHandled { get; }
        TgMedia Map(MessageMedia media);
    }
}