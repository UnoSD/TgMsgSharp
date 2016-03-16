using System;
using System.Collections.Generic;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class Messages_dialogsSliceConstructor : messages_Dialogs
    {
        public int count;
        public List<Dialog> dialogs;
        public List<Message> messages;
        public List<Chat> chats;
        public List<User> users;

        public Messages_dialogsSliceConstructor()
        {

        }

        public Messages_dialogsSliceConstructor(int count, List<Dialog> dialogs, List<Message> messages, List<Chat> chats,
            List<User> users)
        {
            this.count = count;
            this.dialogs = dialogs;
            this.messages = messages;
            this.chats = chats;
            this.users = users;
        }


        public Constructor Constructor
        {
            get { return Constructor.messages_dialogsSlice; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x71e094f3);
            writer.Write(this.count);
            writer.Write(0x1cb5c415);
            writer.Write(this.dialogs.Count);
            foreach (Dialog dialogs_element in this.dialogs)
            {
                dialogs_element.Write(writer);
            }
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
        }

        public override void Read(BinaryReader reader)
        {
            this.count = reader.ReadInt32();
            reader.ReadInt32(); // vector code
            int dialogs_len = reader.ReadInt32();
            this.dialogs = new List<Dialog>(dialogs_len);
            for (int dialogs_index = 0; dialogs_index < dialogs_len; dialogs_index++)
            {
                Dialog dialogs_element;
                dialogs_element = Tl.Parse<Dialog>(reader);
                this.dialogs.Add(dialogs_element);
            }
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
        }

        public override string ToString()
        {
            return String.Format("(messages_dialogsSlice count:{0} dialogs:{1} messages:{2} chats:{3} users:{4})", count,
                Serializers.VectorToString(dialogs), Serializers.VectorToString(messages), Serializers.VectorToString(chats),
                Serializers.VectorToString(users));
        }
    }
}