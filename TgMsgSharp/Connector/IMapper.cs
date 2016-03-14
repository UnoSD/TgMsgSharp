using System.Collections.Generic;

namespace TgMsgSharp.Connector
{
    public interface IMapper<in TFrom, out TTo>
    {
        IEnumerable<TTo> Map(IEnumerable<TFrom> from);
        TTo Map(TFrom from);
    }
}