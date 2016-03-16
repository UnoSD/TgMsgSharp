using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class UpdateUserNameConstructor : Update
    {
        public int user_id;
        public string first_name;
        public string last_name;

        public UpdateUserNameConstructor()
        {

        }

        public UpdateUserNameConstructor(int user_id, string first_name, string last_name)
        {
            this.user_id = user_id;
            this.first_name = first_name;
            this.last_name = last_name;
        }


        public Constructor Constructor
        {
            get { return Constructor.updateUserName; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xda22d9ad);
            writer.Write(this.user_id);
            Serializers.String.write(writer, this.first_name);
            Serializers.String.write(writer, this.last_name);
        }

        public override void Read(BinaryReader reader)
        {
            this.user_id = reader.ReadInt32();
            this.first_name = Serializers.String.read(reader);
            this.last_name = Serializers.String.read(reader);
        }

        public override string ToString()
        {
            return String.Format("(updateUserName user_id:{0} first_name:'{1}' last_name:'{2}')", user_id, first_name, last_name);
        }
    }
}