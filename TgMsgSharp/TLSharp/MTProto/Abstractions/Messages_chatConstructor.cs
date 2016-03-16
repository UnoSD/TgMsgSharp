using System;
using System.Collections.Generic;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class Messages_chatConstructor : messages_Chat
    {
        public Chat chat;
        public List<User> users;

        public Messages_chatConstructor()
        {

        }

        public Messages_chatConstructor(Chat chat, List<User> users)
        {
            this.chat = chat;
            this.users = users;
        }


        public Constructor Constructor
        {
            get { return Constructor.messages_chat; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x40e9002a);
            this.chat.Write(writer);
            writer.Write(0x1cb5c415);
            writer.Write(this.users.Count);
            foreach (User users_element in this.users)
            {
                users_element.Write(writer);
            }
        }

        public override void Read(BinaryReader reader)
        {
            this.chat = Tl.Parse<Chat>(reader);
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
            return String.Format("(messages_chat chat:{0} users:{1})", chat, Serializers.VectorToString(users));
        }
    }
}