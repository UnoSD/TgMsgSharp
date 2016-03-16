using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class UserStatusOfflineConstructor : UserStatus
    {
        public int was_online;

        public UserStatusOfflineConstructor()
        {

        }

        public UserStatusOfflineConstructor(int was_online)
        {
            this.was_online = was_online;
        }


        public Constructor Constructor
        {
            get { return Constructor.userStatusOffline; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x008c703f);
            writer.Write(this.was_online);
        }

        public override void Read(BinaryReader reader)
        {
            this.was_online = reader.ReadInt32();
        }

        public override string ToString()
        {
            return String.Format("(userStatusOffline was_online:{0})", was_online);
        }
    }
}