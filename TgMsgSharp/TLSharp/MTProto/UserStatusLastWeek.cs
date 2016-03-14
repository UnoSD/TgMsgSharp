using System.IO;

namespace TLSharp.Core.MTProto
{
    public class UserStatusLastWeek : UserStatus
    {
        public static Combinator Combinator => new Combinator(0x7bf09fc);

        public override void Write(BinaryWriter writer)
        {
            throw new System.NotImplementedException();
        }

        public override void Read(BinaryReader reader)
        {
        }
    }
}