using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class UpdateChatParticipantDeleteConstructor : Update
    {
        public int chat_id;
        public int user_id;
        public int version;

        public UpdateChatParticipantDeleteConstructor()
        {

        }

        public UpdateChatParticipantDeleteConstructor(int chat_id, int user_id, int version)
        {
            this.chat_id = chat_id;
            this.user_id = user_id;
            this.version = version;
        }


        public Constructor Constructor
        {
            get { return Constructor.updateChatParticipantDelete; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x6e5f8c22);
            writer.Write(this.chat_id);
            writer.Write(this.user_id);
            writer.Write(this.version);
        }

        public override void Read(BinaryReader reader)
        {
            this.chat_id = reader.ReadInt32();
            this.user_id = reader.ReadInt32();
            this.version = reader.ReadInt32();
        }

        public override string ToString()
        {
            return String.Format("(updateChatParticipantDelete chat_id:{0} user_id:{1} version:{2})", chat_id, user_id, version);
        }
    }
}