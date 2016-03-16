using System;
using System.Collections.Generic;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class ChatParticipantsConstructor : ChatParticipants
    {
        public int chat_id;
        public int admin_id;
        public List<ChatParticipant> participants;
        public int version;

        public ChatParticipantsConstructor()
        {

        }

        public ChatParticipantsConstructor(int chat_id, int admin_id, List<ChatParticipant> participants, int version)
        {
            this.chat_id = chat_id;
            this.admin_id = admin_id;
            this.participants = participants;
            this.version = version;
        }


        public Constructor Constructor
        {
            get { return Constructor.chatParticipants; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x7841b415);
            writer.Write(this.chat_id);
            writer.Write(this.admin_id);
            writer.Write(0x1cb5c415);
            writer.Write(this.participants.Count);
            foreach (ChatParticipant participants_element in this.participants)
            {
                participants_element.Write(writer);
            }
            writer.Write(this.version);
        }

        public override void Read(BinaryReader reader)
        {
            this.chat_id = reader.ReadInt32();
            this.admin_id = reader.ReadInt32();
            reader.ReadInt32(); // vector code
            int participants_len = reader.ReadInt32();
            this.participants = new List<ChatParticipant>(participants_len);
            for (int participants_index = 0; participants_index < participants_len; participants_index++)
            {
                ChatParticipant participants_element;
                participants_element = Tl.Parse<ChatParticipant>(reader);
                this.participants.Add(participants_element);
            }
            this.version = reader.ReadInt32();
        }

        public override string ToString()
        {
            return String.Format("(chatParticipants chat_id:{0} admin_id:{1} participants:{2} version:{3})", chat_id, admin_id,
                Serializers.VectorToString(participants), version);
        }
    }
}