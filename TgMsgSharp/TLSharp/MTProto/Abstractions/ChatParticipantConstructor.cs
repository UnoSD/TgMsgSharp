using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class ChatParticipantConstructor : ChatParticipant
    {
        public int user_id;
        public int inviter_id;
        public int date;

        public ChatParticipantConstructor()
        {

        }

        public ChatParticipantConstructor(int user_id, int inviter_id, int date)
        {
            this.user_id = user_id;
            this.inviter_id = inviter_id;
            this.date = date;
        }


        public Constructor Constructor
        {
            get { return Constructor.chatParticipant; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xc8d7493e);
            writer.Write(this.user_id);
            writer.Write(this.inviter_id);
            writer.Write(this.date);
        }

        public override void Read(BinaryReader reader)
        {
            this.user_id = reader.ReadInt32();
            this.inviter_id = reader.ReadInt32();
            this.date = reader.ReadInt32();
        }

        public override string ToString()
        {
            return String.Format("(chatParticipant user_id:{0} inviter_id:{1} date:{2})", user_id, inviter_id, date);
        }
    }
}