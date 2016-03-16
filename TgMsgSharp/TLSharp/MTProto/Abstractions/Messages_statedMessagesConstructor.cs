using System;
using System.Collections.Generic;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class Messages_statedMessagesConstructor : messages_StatedMessages
    {
        public List<Message> messages;
        public List<Chat> chats;
        public List<User> users;
        public int pts;
        public int seq;

        public Messages_statedMessagesConstructor()
        {

        }

        public Messages_statedMessagesConstructor(List<Message> messages, List<Chat> chats, List<User> users, int pts, int seq)
        {
            this.messages = messages;
            this.chats = chats;
            this.users = users;
            this.pts = pts;
            this.seq = seq;
        }


        public Constructor Constructor
        {
            get { return Constructor.messages_statedMessages; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x969478bb);
            writer.Write(0x1cb5c415);
            writer.Write(this.messages.Count);
            foreach (Message messages_element in this.messages)
            {
                messages_element.Write(writer);
            }
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
            writer.Write(this.pts);
            writer.Write(this.seq);
        }

        public override void Read(BinaryReader reader)
        {
            reader.ReadInt32(); // vector code
            int messages_len = reader.ReadInt32();
            this.messages = new List<Message>(messages_len);
            for (int messages_index = 0; messages_index < messages_len; messages_index++)
            {
                Message messages_element;
                messages_element = Tl.Parse<Message>(reader);
                this.messages.Add(messages_element);
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
            reader.ReadInt32(); // vector code
            int users_len = reader.ReadInt32();
            this.users = new List<User>(users_len);
            for (int users_index = 0; users_index < users_len; users_index++)
            {
                User users_element;
                users_element = Tl.Parse<User>(reader);
                this.users.Add(users_element);
            }
            this.pts = reader.ReadInt32();
            this.seq = reader.ReadInt32();
        }

        public override string ToString()
        {
            return String.Format("(messages_statedMessages messages:{0} chats:{1} users:{2} pts:{3} seq:{4})",
                Serializers.VectorToString(messages), Serializers.VectorToString(chats), Serializers.VectorToString(users), pts, seq);
        }
    }
}