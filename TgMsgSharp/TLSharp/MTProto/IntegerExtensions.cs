using System;

namespace TLSharp.Core.MTProto
{
    public static class IntegerExtensions
    {
        public static bool HasFlag(this int value, Enum flag)
        {
            var intFlag = Convert.ToInt32(flag);

            return (value & intFlag) == intFlag;
        }
    }
}