using System.IO;

namespace TLSharp.Core.MTProto
{
    public abstract class TLObject
    {
        public abstract void Write(BinaryWriter writer);
        public abstract void Read(BinaryReader reader);
    }
}