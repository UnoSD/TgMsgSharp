using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class Messages_sentEncryptedFileConstructor : messages_SentEncryptedMessage
    {
        public int date;
        public EncryptedFile file;

        public Messages_sentEncryptedFileConstructor()
        {

        }

        public Messages_sentEncryptedFileConstructor(int date, EncryptedFile file)
        {
            this.date = date;
            this.file = file;
        }


        public Constructor Constructor
        {
            get { return Constructor.messages_sentEncryptedFile; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x9493ff32);
            writer.Write(this.date);
            this.file.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            this.date = reader.ReadInt32();
            this.file = Tl.Parse<EncryptedFile>(reader);
        }

        public override string ToString()
        {
            return String.Format("(messages_sentEncryptedFile date:{0} file:{1})", date, file);
        }
    }
}