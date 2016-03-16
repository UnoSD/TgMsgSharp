using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class EncryptedChatDiscardedConstructor : EncryptedChat
    {
        public int id;

        public EncryptedChatDiscardedConstructor()
        {

        }

        public EncryptedChatDiscardedConstructor(int id)
        {
            this.id = id;
        }


        public Constructor Constructor
        {
            get { return Constructor.encryptedChatDiscarded; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x13d6dd27);
            writer.Write(this.id);
        }

        public override void Read(BinaryReader reader)
        {
            this.id = reader.ReadInt32();
        }

        public override string ToString()
        {
            return String.Format("(encryptedChatDiscarded id:{0})", id);
        }
    }
}