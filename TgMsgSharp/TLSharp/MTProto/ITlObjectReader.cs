using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public interface ITlObjectReader
    {
        T Read<T>(BinaryReader reader, Type typeToCreate);
    }
}