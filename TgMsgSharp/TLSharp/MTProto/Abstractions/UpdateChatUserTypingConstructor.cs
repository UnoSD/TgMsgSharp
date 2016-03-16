using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class UpdateChatUserTypingConstructor : Update
    {
        public int chat_id;
        public int user_id;

        public UpdateChatUserTypingConstructor()
        {

        }

        public UpdateChatUserTypingConstructor(int chat_id, int user_id)
        {
            this.chat_id = chat_id;
            this.user_id = user_id;
        }


        public Constructor Constructor
        {
            get { return Constructor.updateChatUserTyping; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x3c46cfe6);
            writer.Write(this.chat_id);
            writer.Write(this.user_id);
        }

        public override void Read(BinaryReader reader)
        {
            this.chat_id = reader.ReadInt32();
            this.user_id = reader.ReadInt32();
        }

        public override string ToString()
        {
            return String.Format("(updateChatUserTyping chat_id:{0} user_id:{1})", chat_id, user_id);
        }
    }
}