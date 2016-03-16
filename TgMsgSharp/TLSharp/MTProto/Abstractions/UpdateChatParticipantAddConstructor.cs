using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class UpdateChatParticipantAddConstructor : Update
    {
        public int chat_id;
        public int user_id;
        public int inviter_id;
        public int version;

        public UpdateChatParticipantAddConstructor()
        {

        }

        public UpdateChatParticipantAddConstructor(int chat_id, int user_id, int inviter_id, int version)
        {
            this.chat_id = chat_id;
            this.user_id = user_id;
            this.inviter_id = inviter_id;
            this.version = version;
        }


        public Constructor Constructor
        {
            get { return Constructor.updateChatParticipantAdd; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x3a0eeb22);
            writer.Write(this.chat_id);
            writer.Write(this.user_id);
            writer.Write(this.inviter_id);
            writer.Write(this.version);
        }

        public override void Read(BinaryReader reader)
        {
            this.chat_id = reader.ReadInt32();
            this.user_id = reader.ReadInt32();
            this.inviter_id = reader.ReadInt32();
            this.version = reader.ReadInt32();
        }

        public override string ToString()
        {
            return String.Format("(updateChatParticipantAdd chat_id:{0} user_id:{1} inviter_id:{2} version:{3})", chat_id,
                user_id, inviter_id, version);
        }
    }
}