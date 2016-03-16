using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class DecryptedMessageMediaAudioConstructor : DecryptedMessageMedia
    {
        public int duration;
        public int size;
        public byte[] key;
        public byte[] iv;

        public DecryptedMessageMediaAudioConstructor()
        {

        }

        public DecryptedMessageMediaAudioConstructor(int duration, int size, byte[] key, byte[] iv)
        {
            this.duration = duration;
            this.size = size;
            this.key = key;
            this.iv = iv;
        }


        public Constructor Constructor
        {
            get { return Constructor.decryptedMessageMediaAudio; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x6080758f);
            writer.Write(this.duration);
            writer.Write(this.size);
            Serializers.Bytes.write(writer, this.key);
            Serializers.Bytes.write(writer, this.iv);
        }

        public override void Read(BinaryReader reader)
        {
            this.duration = reader.ReadInt32();
            this.size = reader.ReadInt32();
            this.key = Serializers.Bytes.read(reader);
            this.iv = Serializers.Bytes.read(reader);
        }

        public override string ToString()
        {
            return String.Format("(decryptedMessageMediaAudio duration:{0} size:{1} key:{2} iv:{3})", duration, size,
                BitConverter.ToString(key), BitConverter.ToString(iv));
        }
    }
}