using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class EncryptedMessageConstructor : EncryptedMessage
    {
        public long random_id;
        public int chat_id;
        public int date;
        public byte[] bytes;
        public EncryptedFile file;

        public EncryptedMessageConstructor()
        {

        }

        public EncryptedMessageConstructor(long random_id, int chat_id, int date, byte[] bytes, EncryptedFile file)
        {
            this.random_id = random_id;
            this.chat_id = chat_id;
            this.date = date;
            this.bytes = bytes;
            this.file = file;
        }


        public Constructor Constructor
        {
            get { return Constructor.encryptedMessage; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xed18c118);
            writer.Write(this.random_id);
            writer.Write(this.chat_id);
            writer.Write(this.date);
            Serializers.Bytes.write(writer, this.bytes);
            this.file.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            this.random_id = reader.ReadInt64();
            this.chat_id = reader.ReadInt32();
            this.date = reader.ReadInt32();
            this.bytes = Serializers.Bytes.read(reader);
            this.file = Tl.Parse<EncryptedFile>(reader);
        }

        public override string ToString()
        {
            return String.Format("(encryptedMessage random_id:{0} chat_id:{1} date:{2} bytes:{3} file:{4})", random_id, chat_id,
                date, BitConverter.ToString(bytes), file);
        }
    }
}