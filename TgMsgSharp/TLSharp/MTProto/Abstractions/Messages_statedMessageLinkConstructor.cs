using System;
using System.Collections.Generic;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class Messages_statedMessageLinkConstructor : messages_StatedMessage
    {
        public Message message;
        public List<Chat> chats;
        public List<User> users;
        public List<contacts_Link> links;
        public int pts;
        public int seq;

        public Messages_statedMessageLinkConstructor()
        {

        }

        public Messages_statedMessageLinkConstructor(Message message, List<Chat> chats, List<User> users,
            List<contacts_Link> links, int pts, int seq)
        {
            this.message = message;
            this.chats = chats;
            this.users = users;
            this.links = links;
            this.pts = pts;
            this.seq = seq;
        }


        public Constructor Constructor
        {
            get { return Constructor.messages_statedMessageLink; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xa9af2881);
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
            writer.Write(0x1cb5c415);
            writer.Write(this.links.Count);
            foreach (contacts_Link links_element in this.links)
            {
                links_element.Write(writer);
            }
            writer.Write(this.pts);
            writer.Write(this.seq);
        }

        public override void Read(BinaryReader reader)
        {
            this.message = Tl.Parse<Message>(reader);
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
            reader.ReadInt32(); // vector code
            int links_len = reader.ReadInt32();
            this.links = new List<contacts_Link>(links_len);
            for (int links_index = 0; links_index < links_len; links_index++)
            {
                contacts_Link links_element;
                links_element = Tl.Parse<contacts_Link>(reader);
                this.links.Add(links_element);
            }
            this.pts = reader.ReadInt32();
            this.seq = reader.ReadInt32();
        }

        public override string ToString()
        {
            return String.Format("(messages_statedMessageLink message:{0} chats:{1} users:{2} links:{3} pts:{4} seq:{5})",
                message, Serializers.VectorToString(chats), Serializers.VectorToString(users), Serializers.VectorToString(links),
                pts, seq);
        }
    }
}