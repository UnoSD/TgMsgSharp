using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class EncryptedMessageServiceConstructor : EncryptedMessage
    {
        public long random_id;
        public int chat_id;
        public int date;
        public byte[] bytes;

        public EncryptedMessageServiceConstructor()
        {

        }

        public EncryptedMessageServiceConstructor(long random_id, int chat_id, int date, byte[] bytes)
        {
            this.random_id = random_id;
            this.chat_id = chat_id;
            this.date = date;
            this.bytes = bytes;
        }


        public Constructor Constructor
        {
            get { return Constructor.encryptedMessageService; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x23734b06);
            writer.Write(this.random_id);
            writer.Write(this.chat_id);
            writer.Write(this.date);
            Serializers.Bytes.write(writer, this.bytes);
        }

        public override void Read(BinaryReader reader)
        {
            this.random_id = reader.ReadInt64();
            this.chat_id = reader.ReadInt32();
            this.date = reader.ReadInt32();
            this.bytes = Serializers.Bytes.read(reader);
        }

        public override string ToString()
        {
            return String.Format("(encryptedMessageService random_id:{0} chat_id:{1} date:{2} bytes:{3})", random_id, chat_id,
                date, BitConverter.ToString(bytes));
        }
    }
}