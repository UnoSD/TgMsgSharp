using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class UpdateEncryptionConstructor : Update
    {
        public EncryptedChat chat;
        public int date;

        public UpdateEncryptionConstructor()
        {

        }

        public UpdateEncryptionConstructor(EncryptedChat chat, int date)
        {
            this.chat = chat;
            this.date = date;
        }


        public Constructor Constructor
        {
            get { return Constructor.updateEncryption; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xb4a2e88d);
            this.chat.Write(writer);
            writer.Write(this.date);
        }

        public override void Read(BinaryReader reader)
        {
            this.chat = Tl.Parse<EncryptedChat>(reader);
            this.date = reader.ReadInt32();
        }

        public override string ToString()
        {
            return String.Format("(updateEncryption chat:{0} date:{1})", chat, date);
        }
    }
}