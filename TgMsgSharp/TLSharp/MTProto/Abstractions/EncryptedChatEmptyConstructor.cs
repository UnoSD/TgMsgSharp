using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class EncryptedChatEmptyConstructor : EncryptedChat
    {
        public int id;

        public EncryptedChatEmptyConstructor()
        {

        }

        public EncryptedChatEmptyConstructor(int id)
        {
            this.id = id;
        }


        public Constructor Constructor
        {
            get { return Constructor.encryptedChatEmpty; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xab7ec0a0);
            writer.Write(this.id);
        }

        public override void Read(BinaryReader reader)
        {
            this.id = reader.ReadInt32();
        }

        public override string ToString()
        {
            return String.Format("(encryptedChatEmpty id:{0})", id);
        }
    }
}