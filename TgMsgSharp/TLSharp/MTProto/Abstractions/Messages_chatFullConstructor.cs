using System;
using System.Collections.Generic;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class Messages_chatFullConstructor : messages_ChatFull
    {
        public ChatFull full_chat;
        public List<Chat> chats;
        public List<User> users;

        public Messages_chatFullConstructor()
        {

        }

        public Messages_chatFullConstructor(ChatFull full_chat, List<Chat> chats, List<User> users)
        {
            this.full_chat = full_chat;
            this.chats = chats;
            this.users = users;
        }


        public Constructor Constructor
        {
            get { return Constructor.messages_chatFull; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xe5d7d19c);
            this.full_chat.Write(writer);
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
        }

        public override void Read(BinaryReader reader)
        {
            this.full_chat = Tl.Parse<ChatFull>(reader);
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
        }

        public override string ToString()
        {
            return String.Format("(messages_chatFull full_chat:{0} chats:{1} users:{2})", full_chat,
                Serializers.VectorToString(chats), Serializers.VectorToString(users));
        }
    }
}