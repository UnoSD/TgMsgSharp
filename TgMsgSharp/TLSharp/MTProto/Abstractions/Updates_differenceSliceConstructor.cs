using System;
using System.Collections.Generic;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class Updates_differenceSliceConstructor : updates_Difference
    {
        public List<Message> new_messages;
        public List<EncryptedMessage> new_encrypted_messages;
        public List<Update> other_updates;
        public List<Chat> chats;
        public List<User> users;
        public updates_State intermediate_state;

        public Updates_differenceSliceConstructor()
        {

        }

        public Updates_differenceSliceConstructor(List<Message> new_messages, List<EncryptedMessage> new_encrypted_messages,
            List<Update> other_updates, List<Chat> chats, List<User> users, updates_State intermediate_state)
        {
            this.new_messages = new_messages;
            this.new_encrypted_messages = new_encrypted_messages;
            this.other_updates = other_updates;
            this.chats = chats;
            this.users = users;
            this.intermediate_state = intermediate_state;
        }


        public Constructor Constructor
        {
            get { return Constructor.updates_differenceSlice; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xa8fb1981);
            writer.Write(0x1cb5c415);
            writer.Write(this.new_messages.Count);
            foreach (Message new_messages_element in this.new_messages)
            {
                new_messages_element.Write(writer);
            }
            writer.Write(0x1cb5c415);
            writer.Write(this.new_encrypted_messages.Count);
            foreach (EncryptedMessage new_encrypted_messages_element in this.new_encrypted_messages)
            {
                new_encrypted_messages_element.Write(writer);
            }
            writer.Write(0x1cb5c415);
            writer.Write(this.other_updates.Count);
            foreach (Update other_updates_element in this.other_updates)
            {
                other_updates_element.Write(writer);
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
            this.intermediate_state.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            reader.ReadInt32(); // vector code
            int new_messages_len = reader.ReadInt32();
            this.new_messages = new List<Message>(new_messages_len);
            for (int new_messages_index = 0; new_messages_index < new_messages_len; new_messages_index++)
            {
                Message new_messages_element;
                new_messages_element = Tl.Parse<Message>(reader);
                this.new_messages.Add(new_messages_element);
            }
            reader.ReadInt32(); // vector code
            int new_encrypted_messages_len = reader.ReadInt32();
            this.new_encrypted_messages = new List<EncryptedMessage>(new_encrypted_messages_len);
            for (int new_encrypted_messages_index = 0;
                new_encrypted_messages_index < new_encrypted_messages_len;
                new_encrypted_messages_index++)
            {
                EncryptedMessage new_encrypted_messages_element;
                new_encrypted_messages_element = Tl.Parse<EncryptedMessage>(reader);
                this.new_encrypted_messages.Add(new_encrypted_messages_element);
            }
            reader.ReadInt32(); // vector code
            int other_updates_len = reader.ReadInt32();
            this.other_updates = new List<Update>(other_updates_len);
            for (int other_updates_index = 0; other_updates_index < other_updates_len; other_updates_index++)
            {
                Update other_updates_element;
                other_updates_element = Tl.Parse<Update>(reader);
                this.other_updates.Add(other_updates_element);
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
            this.intermediate_state = Tl.Parse<updates_State>(reader);
        }

        public override string ToString()
        {
            return
                String.Format(
                    "(updates_differenceSlice new_messages:{0} new_encrypted_messages:{1} other_updates:{2} chats:{3} users:{4} intermediate_state:{5})",
                    Serializers.VectorToString(new_messages), Serializers.VectorToString(new_encrypted_messages),
                    Serializers.VectorToString(other_updates), Serializers.VectorToString(chats), Serializers.VectorToString(users),
                    intermediate_state);
        }
    }
}