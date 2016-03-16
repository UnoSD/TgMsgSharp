using System;
using System.Collections.Generic;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class UpdateDeleteMessagesConstructor : Update
    {
        public List<int> messages;
        public int pts;

        public UpdateDeleteMessagesConstructor()
        {

        }

        public UpdateDeleteMessagesConstructor(List<int> messages, int pts)
        {
            this.messages = messages;
            this.pts = pts;
        }


        public Constructor Constructor
        {
            get { return Constructor.updateDeleteMessages; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xa92bfe26);
            writer.Write(0x1cb5c415);
            writer.Write(this.messages.Count);
            foreach (int messages_element in this.messages)
            {
                writer.Write(messages_element);
            }
            writer.Write(this.pts);
        }

        public override void Read(BinaryReader reader)
        {
            reader.ReadInt32(); // vector code
            int messages_len = reader.ReadInt32();
            this.messages = new List<int>(messages_len);
            for (int messages_index = 0; messages_index < messages_len; messages_index++)
            {
                int messages_element;
                messages_element = reader.ReadInt32();
                this.messages.Add(messages_element);
            }
            this.pts = reader.ReadInt32();
        }

        public override string ToString()
        {
            return String.Format("(updateDeleteMessages messages:{0} pts:{1})", Serializers.VectorToString(messages), pts);
        }
    }
}