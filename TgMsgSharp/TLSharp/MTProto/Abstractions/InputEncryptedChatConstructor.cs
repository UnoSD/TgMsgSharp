using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class InputEncryptedChatConstructor : InputEncryptedChat
    {
        public int chat_id;
        public long access_hash;

        public InputEncryptedChatConstructor()
        {

        }

        public InputEncryptedChatConstructor(int chat_id, long access_hash)
        {
            this.chat_id = chat_id;
            this.access_hash = access_hash;
        }


        public Constructor Constructor
        {
            get { return Constructor.inputEncryptedChat; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xf141b5e1);
            writer.Write(this.chat_id);
            writer.Write(this.access_hash);
        }

        public override void Read(BinaryReader reader)
        {
            this.chat_id = reader.ReadInt32();
            this.access_hash = reader.ReadInt64();
        }

        public override string ToString()
        {
            return String.Format("(inputEncryptedChat chat_id:{0} access_hash:{1})", chat_id, access_hash);
        }
    }
}