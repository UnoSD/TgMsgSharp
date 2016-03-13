using System;
using System.Diagnostics;

namespace TLSharp.Core.MTProto
{
    [DebuggerDisplay(nameof(ToHex))]
    public struct Combinator
    {
        public uint DataCode { get; set; }

        public string ToHex => DataCode.ToString("X");

        public Type ToType => TL.GetCombinatorType(DataCode);

        public Combinator(uint dataCode)
        {
            DataCode = dataCode;
        }
    }
}