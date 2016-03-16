using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class UserStatusEmptyConstructor : UserStatus
    {

        public UserStatusEmptyConstructor()
        {

        }



        public Constructor Constructor
        {
            get { return Constructor.userStatusEmpty; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x09d05049);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return String.Format("(userStatusEmpty)");
        }
    }
}