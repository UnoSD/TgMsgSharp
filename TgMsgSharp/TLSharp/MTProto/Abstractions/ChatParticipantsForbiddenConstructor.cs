using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class ChatParticipantsForbiddenConstructor : ChatParticipants
    {
        public int chat_id;

        public ChatParticipantsForbiddenConstructor()
        {

        }

        public ChatParticipantsForbiddenConstructor(int chat_id)
        {
            this.chat_id = chat_id;
        }


        public Constructor Constructor
        {
            get { return Constructor.chatParticipantsForbidden; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x0fd2bb8a);
            writer.Write(this.chat_id);
        }

        public override void Read(BinaryReader reader)
        {
            this.chat_id = reader.ReadInt32();
        }

        public override string ToString()
        {
            return String.Format("(chatParticipantsForbidden chat_id:{0})", chat_id);
        }
    }
}