using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class DecryptedMessageMediaPhotoConstructor : DecryptedMessageMedia
    {
        public byte[] thumb;
        public int thumb_w;
        public int thumb_h;
        public int w;
        public int h;
        public int size;
        public byte[] key;
        public byte[] iv;

        public DecryptedMessageMediaPhotoConstructor()
        {

        }

        public DecryptedMessageMediaPhotoConstructor(byte[] thumb, int thumb_w, int thumb_h, int w, int h, int size,
            byte[] key, byte[] iv)
        {
            this.thumb = thumb;
            this.thumb_w = thumb_w;
            this.thumb_h = thumb_h;
            this.w = w;
            this.h = h;
            this.size = size;
            this.key = key;
            this.iv = iv;
        }


        public Constructor Constructor
        {
            get { return Constructor.decryptedMessageMediaPhoto; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x32798a8c);
            Serializers.Bytes.write(writer, this.thumb);
            writer.Write(this.thumb_w);
            writer.Write(this.thumb_h);
            writer.Write(this.w);
            writer.Write(this.h);
            writer.Write(this.size);
            Serializers.Bytes.write(writer, this.key);
            Serializers.Bytes.write(writer, this.iv);
        }

        public override void Read(BinaryReader reader)
        {
            this.thumb = Serializers.Bytes.read(reader);
            this.thumb_w = reader.ReadInt32();
            this.thumb_h = reader.ReadInt32();
            this.w = reader.ReadInt32();
            this.h = reader.ReadInt32();
            this.size = reader.ReadInt32();
            this.key = Serializers.Bytes.read(reader);
            this.iv = Serializers.Bytes.read(reader);
        }

        public override string ToString()
        {
            return
                String.Format("(decryptedMessageMediaPhoto thumb:{0} thumb_w:{1} thumb_h:{2} w:{3} h:{4} size:{5} key:{6} iv:{7})",
                    BitConverter.ToString(thumb), thumb_w, thumb_h, w, h, size, BitConverter.ToString(key), BitConverter.ToString(iv));
        }
    }
}