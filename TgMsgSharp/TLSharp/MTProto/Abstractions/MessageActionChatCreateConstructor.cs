using System;
using System.Collections.Generic;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class MessageActionChatCreateConstructor : MessageAction
    {
        public string title;
        public List<int> users;

        public MessageActionChatCreateConstructor()
        {

        }

        public MessageActionChatCreateConstructor(string title, List<int> users)
        {
            this.title = title;
            this.users = users;
        }


        public Constructor Constructor
        {
            get { return Constructor.messageActionChatCreate; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xa6638b9a);
            Serializers.String.write(writer, this.title);
            writer.Write(0x1cb5c415);
            writer.Write(this.users.Count);
            foreach (int users_element in this.users)
            {
                writer.Write(users_element);
            }
        }

        public override void Read(BinaryReader reader)
        {
            this.title = Serializers.String.read(reader);
            reader.ReadInt32(); // vector code
            int users_len = reader.ReadInt32();
            this.users = new List<int>(users_len);
            for (int users_index = 0; users_index < users_len; users_index++)
            {
                int users_element;
                users_element = reader.ReadInt32();
                this.users.Add(users_element);
            }
        }

        public override string ToString()
        {
            return String.Format("(messageActionChatCreate title:'{0}' users:{1})", title, Serializers.VectorToString(users));
        }
    }
}