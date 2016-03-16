using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class InputPhoneContactConstructor : InputContact
    {
        public long client_id;
        public string phone;
        public string first_name;
        public string last_name;

        public InputPhoneContactConstructor()
        {

        }

        public InputPhoneContactConstructor(long client_id, string phone, string first_name, string last_name)
        {
            this.client_id = client_id;
            this.phone = phone;
            this.first_name = first_name;
            this.last_name = last_name;
        }


        public Constructor Constructor
        {
            get { return Constructor.inputPhoneContact; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xf392b7f4);
            writer.Write(this.client_id);
            Serializers.String.write(writer, this.phone);
            Serializers.String.write(writer, this.first_name);
            Serializers.String.write(writer, this.last_name);
        }

        public override void Read(BinaryReader reader)
        {
            this.client_id = reader.ReadInt64();
            this.phone = Serializers.String.read(reader);
            this.first_name = Serializers.String.read(reader);
            this.last_name = Serializers.String.read(reader);
        }

        public override string ToString()
        {
            return String.Format("(inputPhoneContact client_id:{0} phone:'{1}' first_name:'{2}' last_name:'{3}')", client_id,
                phone, first_name, last_name);
        }
    }
}