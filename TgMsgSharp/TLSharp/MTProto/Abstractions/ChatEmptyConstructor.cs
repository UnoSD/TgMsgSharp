using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class ChatEmptyConstructor : Chat
    {
        public int id;

        public ChatEmptyConstructor()
        {

        }

        public ChatEmptyConstructor(int id)
        {
            this.id = id;
        }


        public Constructor Constructor
        {
            get { return Constructor.chatEmpty; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x9ba2d800);
            writer.Write(this.id);
        }

        public override void Read(BinaryReader reader)
        {
            this.id = reader.ReadInt32();
        }

        public override string ToString()
        {
            return String.Format("(chatEmpty id:{0})", id);
        }
    }
}