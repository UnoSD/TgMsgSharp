using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class MessageMediaContactConstructor : MessageMedia
    {
        public string phone_number;
        public string first_name;
        public string last_name;
        public int user_id;

        public MessageMediaContactConstructor()
        {

        }

        public MessageMediaContactConstructor(string phone_number, string first_name, string last_name, int user_id)
        {
            this.phone_number = phone_number;
            this.first_name = first_name;
            this.last_name = last_name;
            this.user_id = user_id;
        }


        public Constructor Constructor
        {
            get { return Constructor.messageMediaContact; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x5e7d2f39);
            Serializers.String.write(writer, this.phone_number);
            Serializers.String.write(writer, this.first_name);
            Serializers.String.write(writer, this.last_name);
            writer.Write(this.user_id);
        }

        public override void Read(BinaryReader reader)
        {
            this.phone_number = Serializers.String.read(reader);
            this.first_name = Serializers.String.read(reader);
            this.last_name = Serializers.String.read(reader);
            this.user_id = reader.ReadInt32();
        }

        public override string ToString()
        {
            return String.Format("(messageMediaContact phone_number:'{0}' first_name:'{1}' last_name:'{2}' user_id:{3})",
                phone_number, first_name, last_name, user_id);
        }
    }
}