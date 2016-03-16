using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class Messages_dhConfigNotModifiedConstructor : messages_DhConfig
    {
        public byte[] random;

        public Messages_dhConfigNotModifiedConstructor()
        {

        }

        public Messages_dhConfigNotModifiedConstructor(byte[] random)
        {
            this.random = random;
        }


        public Constructor Constructor
        {
            get { return Constructor.messages_dhConfigNotModified; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xc0e24635);
            Serializers.Bytes.write(writer, this.random);
        }

        public override void Read(BinaryReader reader)
        {
            this.random = Serializers.Bytes.read(reader);
        }

        public override string ToString()
        {
            return String.Format("(messages_dhConfigNotModified random:{0})", BitConverter.ToString(random));
        }
    }
}