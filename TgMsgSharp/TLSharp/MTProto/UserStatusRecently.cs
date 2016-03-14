using System.IO;

namespace TLSharp.Core.MTProto
{
    public class UserStatusRecently : UserStatus
    {
        public static Combinator Combinator => new Combinator(0xe26f42f1);

        public override void Write(BinaryWriter writer)
        {
            throw new System.NotImplementedException();
        }

        public override void Read(BinaryReader reader)
        {
        }
    }
}