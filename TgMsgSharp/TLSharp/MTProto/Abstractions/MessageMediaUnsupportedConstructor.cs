using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class MessageMediaUnsupportedConstructor : MessageMedia
    {
        public byte[] bytes;

        public MessageMediaUnsupportedConstructor()
        {

        }

        public MessageMediaUnsupportedConstructor(byte[] bytes)
        {
            this.bytes = bytes;
        }


        public Constructor Constructor
        {
            get { return Constructor.messageMediaUnsupported; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x29632a36);
            Serializers.Bytes.write(writer, this.bytes);
        }

        public override void Read(BinaryReader reader)
        {
            this.bytes = Serializers.Bytes.read(reader);
        }

        public override string ToString()
        {
            return String.Format("(messageMediaUnsupported bytes:{0})", BitConverter.ToString(bytes));
        }
    }
}