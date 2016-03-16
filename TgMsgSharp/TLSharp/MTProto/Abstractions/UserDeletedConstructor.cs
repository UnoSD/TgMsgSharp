using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class UserDeletedConstructor : User
    {
        public int id;
        public string first_name;
        public string last_name;

        public UserDeletedConstructor()
        {

        }

        public UserDeletedConstructor(int id, string first_name, string last_name)
        {
            this.id = id;
            this.first_name = first_name;
            this.last_name = last_name;
        }


        public Constructor Constructor
        {
            get { return Constructor.userDeleted; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xb29ad7cc);
            writer.Write(this.id);
            Serializers.String.write(writer, this.first_name);
            Serializers.String.write(writer, this.last_name);
        }

        public override void Read(BinaryReader reader)
        {
            this.id = reader.ReadInt32();
            this.first_name = Serializers.String.read(reader);
            this.last_name = Serializers.String.read(reader);
        }

        public override string ToString()
        {
            return String.Format("(userDeleted id:{0} first_name:'{1}' last_name:'{2}')", id, first_name, last_name);
        }
    }
}