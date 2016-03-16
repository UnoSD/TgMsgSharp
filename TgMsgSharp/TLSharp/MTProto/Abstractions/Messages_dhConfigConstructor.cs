using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class Messages_dhConfigConstructor : messages_DhConfig
    {
        public int g;
        public byte[] p;
        public int version;
        public byte[] random;

        public Messages_dhConfigConstructor()
        {

        }

        public Messages_dhConfigConstructor(int g, byte[] p, int version, byte[] random)
        {
            this.g = g;
            this.p = p;
            this.version = version;
            this.random = random;
        }


        public Constructor Constructor
        {
            get { return Constructor.messages_dhConfig; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x2c221edd);
            writer.Write(this.g);
            Serializers.Bytes.write(writer, this.p);
            writer.Write(this.version);
            Serializers.Bytes.write(writer, this.random);
        }

        public override void Read(BinaryReader reader)
        {
            this.g = reader.ReadInt32();
            this.p = Serializers.Bytes.read(reader);
            this.version = reader.ReadInt32();
            this.random = Serializers.Bytes.read(reader);
        }

        public override string ToString()
        {
            return String.Format("(messages_dhConfig g:{0} p:{1} version:{2} random:{3})", g, BitConverter.ToString(p), version,
                BitConverter.ToString(random));
        }
    }
}