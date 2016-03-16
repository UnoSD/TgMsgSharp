using System;
using System.Collections.Generic;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class UpdatesCombinedConstructor : Updates
    {
        public List<Update> updates;
        public List<User> users;
        public List<Chat> chats;
        public int date;
        public int seq_start;
        public int seq;

        public UpdatesCombinedConstructor()
        {

        }

        public UpdatesCombinedConstructor(List<Update> updates, List<User> users, List<Chat> chats, int date, int seq_start,
            int seq)
        {
            this.updates = updates;
            this.users = users;
            this.chats = chats;
            this.date = date;
            this.seq_start = seq_start;
            this.seq = seq;
        }


        public Constructor Constructor
        {
            get { return Constructor.updatesCombined; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x725b04c3);
            writer.Write(0x1cb5c415);
            writer.Write(this.updates.Count);
            foreach (Update updates_element in this.updates)
            {
                updates_element.Write(writer);
            }
            writer.Write(0x1cb5c415);
            writer.Write(this.users.Count);
            foreach (User users_element in this.users)
            {
                users_element.Write(writer);
            }
            writer.Write(0x1cb5c415);
            writer.Write(this.chats.Count);
            foreach (Chat chats_element in this.chats)
            {
                chats_element.Write(writer);
            }
            writer.Write(this.date);
            writer.Write(this.seq_start);
            writer.Write(this.seq);
        }

        public override void Read(BinaryReader reader)
        {
            reader.ReadInt32(); // vector code
            int updates_len = reader.ReadInt32();
            this.updates = new List<Update>(updates_len);
            for (int updates_index = 0; updates_index < updates_len; updates_index++)
            {
                Update updates_element;
                updates_element = Tl.Parse<Update>(reader);
                this.updates.Add(updates_element);
            }
            reader.ReadInt32(); // vector code
            int users_len = reader.ReadInt32();
            this.users = new List<User>(users_len);
            for (int users_index = 0; users_index < users_len; users_index++)
            {
                User users_element;
                users_element = Tl.Parse<User>(reader);
                this.users.Add(users_element);
            }
            reader.ReadInt32(); // vector code
            int chats_len = reader.ReadInt32();
            this.chats = new List<Chat>(chats_len);
            for (int chats_index = 0; chats_index < chats_len; chats_index++)
            {
                Chat chats_element;
                chats_element = Tl.Parse<Chat>(reader);
                this.chats.Add(chats_element);
            }
            this.date = reader.ReadInt32();
            this.seq_start = reader.ReadInt32();
            this.seq = reader.ReadInt32();
        }

        public override string ToString()
        {
            return String.Format("(updatesCombined updates:{0} users:{1} chats:{2} date:{3} seq_start:{4} seq:{5})",
                Serializers.VectorToString(updates), Serializers.VectorToString(users), Serializers.VectorToString(chats), date,
                seq_start, seq);
        }
    }
}