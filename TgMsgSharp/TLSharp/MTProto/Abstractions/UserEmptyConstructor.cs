using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class UserEmptyConstructor : User
    {
        public int id;

        public UserEmptyConstructor()
        {

        }

        public UserEmptyConstructor(int id)
        {
            this.id = id;
        }


        public Constructor Constructor
        {
            get { return Constructor.userEmpty; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x200250ba);
            writer.Write(this.id);
        }

        public override void Read(BinaryReader reader)
        {
            this.id = reader.ReadInt32();
        }

        public override string ToString()
        {
            return String.Format("(userEmpty id:{0})", id);
        }
    }
}