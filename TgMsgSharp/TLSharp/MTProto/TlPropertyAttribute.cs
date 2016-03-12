using System;

namespace TLSharp.Core.MTProto
{
    public class TlPropertyAttribute : Attribute
    {
        public int Order { get; }

        public TlPropertyAttribute(int order)
        {
            Order = order;
        }
    }
}