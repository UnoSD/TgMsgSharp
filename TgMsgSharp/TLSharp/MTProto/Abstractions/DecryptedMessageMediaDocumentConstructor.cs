using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class DecryptedMessageMediaDocumentConstructor : DecryptedMessageMedia
    {
        public byte[] thumb;
        public int thumb_w;
        public int thumb_h;
        public string file_name;
        public string mime_type;
        public int size;
        public byte[] key;
        public byte[] iv;

        public DecryptedMessageMediaDocumentConstructor()
        {

        }

        public DecryptedMessageMediaDocumentConstructor(byte[] thumb, int thumb_w, int thumb_h, string file_name,
            string mime_type, int size, byte[] key, byte[] iv)
        {
            this.thumb = thumb;
            this.thumb_w = thumb_w;
            this.thumb_h = thumb_h;
            this.file_name = file_name;
            this.mime_type = mime_type;
            this.size = size;
            this.key = key;
            this.iv = iv;
        }


        public Constructor Constructor
        {
            get { return Constructor.decryptedMessageMediaDocument; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xb095434b);
            Serializers.Bytes.write(writer, this.thumb);
            writer.Write(this.thumb_w);
            writer.Write(this.thumb_h);
            Serializers.String.write(writer, this.file_name);
            Serializers.String.write(writer, this.mime_type);
            writer.Write(this.size);
            Serializers.Bytes.write(writer, this.key);
            Serializers.Bytes.write(writer, this.iv);
        }

        public override void Read(BinaryReader reader)
        {
            this.thumb = Serializers.Bytes.read(reader);
            this.thumb_w = reader.ReadInt32();
            this.thumb_h = reader.ReadInt32();
            this.file_name = Serializers.String.read(reader);
            this.mime_type = Serializers.String.read(reader);
            this.size = reader.ReadInt32();
            this.key = Serializers.Bytes.read(reader);
            this.iv = Serializers.Bytes.read(reader);
        }

        public override string ToString()
        {
            return
                String.Format(
                    "(decryptedMessageMediaDocument thumb:{0} thumb_w:{1} thumb_h:{2} file_name:'{3}' mime_type:'{4}' size:{5} key:{6} iv:{7})",
                    BitConverter.ToString(thumb), thumb_w, thumb_h, file_name, mime_type, size, BitConverter.ToString(key),
                    BitConverter.ToString(iv));
        }
    }
}