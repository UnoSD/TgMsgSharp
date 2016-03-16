using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class ChatLocatedConstructor : ChatLocated
    {
        public int chat_id;
        public int distance;

        public ChatLocatedConstructor()
        {

        }

        public ChatLocatedConstructor(int chat_id, int distance)
        {
            this.chat_id = chat_id;
            this.distance = distance;
        }


        public Constructor Constructor
        {
            get { return Constructor.chatLocated; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x3631cf4c);
            writer.Write(this.chat_id);
            writer.Write(this.distance);
        }

        public override void Read(BinaryReader reader)
        {
            this.chat_id = reader.ReadInt32();
            this.distance = reader.ReadInt32();
        }

        public override string ToString()
        {
            return String.Format("(chatLocated chat_id:{0} distance:{1})", chat_id, distance);
        }
    }
}