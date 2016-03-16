using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class InputMediaContactConstructor : InputMedia
    {
        public string phone_number;
        public string first_name;
        public string last_name;

        public InputMediaContactConstructor()
        {

        }

        public InputMediaContactConstructor(string phone_number, string first_name, string last_name)
        {
            this.phone_number = phone_number;
            this.first_name = first_name;
            this.last_name = last_name;
        }


        public Constructor Constructor
        {
            get { return Constructor.inputMediaContact; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xa6e45987);
            Serializers.String.write(writer, this.phone_number);
            Serializers.String.write(writer, this.first_name);
            Serializers.String.write(writer, this.last_name);
        }

        public override void Read(BinaryReader reader)
        {
            this.phone_number = Serializers.String.read(reader);
            this.first_name = Serializers.String.read(reader);
            this.last_name = Serializers.String.read(reader);
        }

        public override string ToString()
        {
            return String.Format("(inputMediaContact phone_number:'{0}' first_name:'{1}' last_name:'{2}')", phone_number,
                first_name, last_name);
        }
    }
}