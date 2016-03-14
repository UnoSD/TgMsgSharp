using System.IO;

namespace TLSharp.Core.MTProto
{
    public class UserStatusLastMonth : UserStatus
    {
        public static Combinator Combinator => new Combinator(0x77ebc742);

        public override void Write(BinaryWriter writer)
        {
            throw new System.NotImplementedException();
        }

        public override void Read(BinaryReader reader)
        {
        }
    }
}