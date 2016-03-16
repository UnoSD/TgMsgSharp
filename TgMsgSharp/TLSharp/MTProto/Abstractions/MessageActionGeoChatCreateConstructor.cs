using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class MessageActionGeoChatCreateConstructor : MessageAction
    {
        public string title;
        public string address;

        public MessageActionGeoChatCreateConstructor()
        {

        }

        public MessageActionGeoChatCreateConstructor(string title, string address)
        {
            this.title = title;
            this.address = address;
        }


        public Constructor Constructor
        {
            get { return Constructor.messageActionGeoChatCreate; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x6f038ebc);
            Serializers.String.write(writer, this.title);
            Serializers.String.write(writer, this.address);
        }

        public override void Read(BinaryReader reader)
        {
            this.title = Serializers.String.read(reader);
            this.address = Serializers.String.read(reader);
        }

        public override string ToString()
        {
            return String.Format("(messageActionGeoChatCreate title:'{0}' address:'{1}')", title, address);
        }
    }
}