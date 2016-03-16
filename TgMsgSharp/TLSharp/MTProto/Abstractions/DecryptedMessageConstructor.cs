using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class DecryptedMessageConstructor : DecryptedMessage
    {
        public long random_id;
        public byte[] random_bytes;
        public string message;
        public DecryptedMessageMedia media;

        public DecryptedMessageConstructor()
        {

        }

        public DecryptedMessageConstructor(long random_id, byte[] random_bytes, string message, DecryptedMessageMedia media)
        {
            this.random_id = random_id;
            this.random_bytes = random_bytes;
            this.message = message;
            this.media = media;
        }


        public Constructor Constructor
        {
            get { return Constructor.decryptedMessage; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x1f814f1f);
            writer.Write(this.random_id);
            Serializers.Bytes.write(writer, this.random_bytes);
            Serializers.String.write(writer, this.message);
            this.media.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            this.random_id = reader.ReadInt64();
            this.random_bytes = Serializers.Bytes.read(reader);
            this.message = Serializers.String.read(reader);
            this.media = Tl.Parse<DecryptedMessageMedia>(reader);
        }

        public override string ToString()
        {
            return String.Format("(decryptedMessage random_id:{0} random_bytes:{1} message:'{2}' media:{3})", random_id,
                BitConverter.ToString(random_bytes), message, media);
        }
    }
}