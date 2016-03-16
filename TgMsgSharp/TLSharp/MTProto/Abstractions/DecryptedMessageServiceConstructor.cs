using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class DecryptedMessageServiceConstructor : DecryptedMessage
    {
        public long random_id;
        public byte[] random_bytes;
        public DecryptedMessageAction action;

        public DecryptedMessageServiceConstructor()
        {

        }

        public DecryptedMessageServiceConstructor(long random_id, byte[] random_bytes, DecryptedMessageAction action)
        {
            this.random_id = random_id;
            this.random_bytes = random_bytes;
            this.action = action;
        }


        public Constructor Constructor
        {
            get { return Constructor.decryptedMessageService; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xaa48327d);
            writer.Write(this.random_id);
            Serializers.Bytes.write(writer, this.random_bytes);
            this.action.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            this.random_id = reader.ReadInt64();
            this.random_bytes = Serializers.Bytes.read(reader);
            this.action = Tl.Parse<DecryptedMessageAction>(reader);
        }

        public override string ToString()
        {
            return String.Format("(decryptedMessageService random_id:{0} random_bytes:{1} action:{2})", random_id,
                BitConverter.ToString(random_bytes), action);
        }
    }
}