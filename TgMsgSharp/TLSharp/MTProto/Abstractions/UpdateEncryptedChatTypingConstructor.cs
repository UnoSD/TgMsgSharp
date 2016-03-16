using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class UpdateEncryptedChatTypingConstructor : Update
    {
        public int chat_id;

        public UpdateEncryptedChatTypingConstructor()
        {

        }

        public UpdateEncryptedChatTypingConstructor(int chat_id)
        {
            this.chat_id = chat_id;
        }


        public Constructor Constructor
        {
            get { return Constructor.updateEncryptedChatTyping; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x1710f156);
            writer.Write(this.chat_id);
        }

        public override void Read(BinaryReader reader)
        {
            this.chat_id = reader.ReadInt32();
        }

        public override string ToString()
        {
            return String.Format("(updateEncryptedChatTyping chat_id:{0})", chat_id);
        }
    }
}