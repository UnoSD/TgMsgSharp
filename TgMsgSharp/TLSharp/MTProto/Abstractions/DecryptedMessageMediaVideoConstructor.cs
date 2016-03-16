using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class DecryptedMessageMediaVideoConstructor : DecryptedMessageMedia
    {
        public byte[] thumb;
        public int thumb_w;
        public int thumb_h;
        public int duration;
        public int w;
        public int h;
        public int size;
        public byte[] key;
        public byte[] iv;

        public DecryptedMessageMediaVideoConstructor()
        {

        }

        public DecryptedMessageMediaVideoConstructor(byte[] thumb, int thumb_w, int thumb_h, int duration, int w, int h,
            int size, byte[] key, byte[] iv)
        {
            this.thumb = thumb;
            this.thumb_w = thumb_w;
            this.thumb_h = thumb_h;
            this.duration = duration;
            this.w = w;
            this.h = h;
            this.size = size;
            this.key = key;
            this.iv = iv;
        }


        public Constructor Constructor
        {
            get { return Constructor.decryptedMessageMediaVideo; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x4cee6ef3);
            Serializers.Bytes.write(writer, this.thumb);
            writer.Write(this.thumb_w);
            writer.Write(this.thumb_h);
            writer.Write(this.duration);
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
            this.duration = reader.ReadInt32();
            this.w = reader.ReadInt32();
            this.h = reader.ReadInt32();
            this.size = reader.ReadInt32();
            this.key = Serializers.Bytes.read(reader);
            this.iv = Serializers.Bytes.read(reader);
        }

        public override string ToString()
        {
            return
                String.Format(
                    "(decryptedMessageMediaVideo thumb:{0} thumb_w:{1} thumb_h:{2} duration:{3} w:{4} h:{5} size:{6} key:{7} iv:{8})",
                    BitConverter.ToString(thumb), thumb_w, thumb_h, duration, w, h, size, BitConverter.ToString(key),
                    BitConverter.ToString(iv));
        }
    }
}