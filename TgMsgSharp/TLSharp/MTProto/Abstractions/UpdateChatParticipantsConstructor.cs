using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class UpdateChatParticipantsConstructor : Update
    {
        public ChatParticipants participants;

        public UpdateChatParticipantsConstructor()
        {

        }

        public UpdateChatParticipantsConstructor(ChatParticipants participants)
        {
            this.participants = participants;
        }


        public Constructor Constructor
        {
            get { return Constructor.updateChatParticipants; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x07761198);
            this.participants.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            this.participants = Tl.Parse<ChatParticipants>(reader);
        }

        public override string ToString()
        {
            return String.Format("(updateChatParticipants participants:{0})", participants);
        }
    }
}