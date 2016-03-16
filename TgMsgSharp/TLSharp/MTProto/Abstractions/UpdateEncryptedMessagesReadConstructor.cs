using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class UpdateEncryptedMessagesReadConstructor : Update
    {
        public int chat_id;
        public int max_date;
        public int date;

        public UpdateEncryptedMessagesReadConstructor()
        {

        }

        public UpdateEncryptedMessagesReadConstructor(int chat_id, int max_date, int date)
        {
            this.chat_id = chat_id;
            this.max_date = max_date;
            this.date = date;
        }


        public Constructor Constructor
        {
            get { return Constructor.updateEncryptedMessagesRead; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x38fe25b7);
            writer.Write(this.chat_id);
            writer.Write(this.max_date);
            writer.Write(this.date);
        }

        public override void Read(BinaryReader reader)
        {
            this.chat_id = reader.ReadInt32();
            this.max_date = reader.ReadInt32();
            this.date = reader.ReadInt32();
        }

        public override string ToString()
        {
            return String.Format("(updateEncryptedMessagesRead chat_id:{0} max_date:{1} date:{2})", chat_id, max_date, date);
        }
    }
}