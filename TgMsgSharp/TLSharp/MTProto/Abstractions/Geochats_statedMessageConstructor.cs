using System;
using System.Collections.Generic;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class Geochats_statedMessageConstructor : geochats_StatedMessage
    {
        public GeoChatMessage message;
        public List<Chat> chats;
        public List<User> users;
        public int seq;

        public Geochats_statedMessageConstructor()
        {

        }

        public Geochats_statedMessageConstructor(GeoChatMessage message, List<Chat> chats, List<User> users, int seq)
        {
            this.message = message;
            this.chats = chats;
            this.users = users;
            this.seq = seq;
        }


        public Constructor Constructor
        {
            get { return Constructor.geochats_statedMessage; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x17b1578b);
            this.message.Write(writer);
            writer.Write(0x1cb5c415);
            writer.Write(this.chats.Count);
            foreach (Chat chats_element in this.chats)
            {
                chats_element.Write(writer);
            }
            writer.Write(0x1cb5c415);
            writer.Write(this.users.Count);
            foreach (User users_element in this.users)
            {
                users_element.Write(writer);
            }
            writer.Write(this.seq);
        }

        public override void Read(BinaryReader reader)
        {
            this.message = Tl.Parse<GeoChatMessage>(reader);
            reader.ReadInt32(); // vector code
            int chats_len = reader.ReadInt32();
            this.chats = new List<Chat>(chats_len);
            for (int chats_index = 0; chats_index < chats_len; chats_index++)
            {
                Chat chats_element;
                chats_element = Tl.Parse<Chat>(reader);
                this.chats.Add(chats_element);
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
            this.seq = reader.ReadInt32();
        }

        public override string ToString()
        {
            return String.Format("(geochats_statedMessage message:{0} chats:{1} users:{2} seq:{3})", message,
                Serializers.VectorToString(chats), Serializers.VectorToString(users), seq);
        }
    }
}