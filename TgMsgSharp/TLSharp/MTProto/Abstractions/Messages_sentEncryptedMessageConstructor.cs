using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class Messages_sentEncryptedMessageConstructor : messages_SentEncryptedMessage
    {
        public int date;

        public Messages_sentEncryptedMessageConstructor()
        {

        }

        public Messages_sentEncryptedMessageConstructor(int date)
        {
            this.date = date;
        }


        public Constructor Constructor
        {
            get { return Constructor.messages_sentEncryptedMessage; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x560f8935);
            writer.Write(this.date);
        }

        public override void Read(BinaryReader reader)
        {
            this.date = reader.ReadInt32();
        }

        public override string ToString()
        {
            return String.Format("(messages_sentEncryptedMessage date:{0})", date);
        }
    }
}