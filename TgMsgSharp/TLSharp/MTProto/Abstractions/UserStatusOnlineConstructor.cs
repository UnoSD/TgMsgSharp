using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class UserStatusOnlineConstructor : UserStatus
    {
        public int expires;

        public UserStatusOnlineConstructor()
        {

        }

        public UserStatusOnlineConstructor(int expires)
        {
            this.expires = expires;
        }


        public Constructor Constructor
        {
            get { return Constructor.userStatusOnline; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xedb93949);
            writer.Write(this.expires);
        }

        public override void Read(BinaryReader reader)
        {
            this.expires = reader.ReadInt32();
        }

        public override string ToString()
        {
            return String.Format("(userStatusOnline expires:{0})", expires);
        }
    }
}