using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class GeoChatMessageEmptyConstructor : GeoChatMessage
    {
        public int chat_id;
        public int id;

        public GeoChatMessageEmptyConstructor()
        {

        }

        public GeoChatMessageEmptyConstructor(int chat_id, int id)
        {
            this.chat_id = chat_id;
            this.id = id;
        }


        public Constructor Constructor
        {
            get { return Constructor.geoChatMessageEmpty; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x60311a9b);
            writer.Write(this.chat_id);
            writer.Write(this.id);
        }

        public override void Read(BinaryReader reader)
        {
            this.chat_id = reader.ReadInt32();
            this.id = reader.ReadInt32();
        }

        public override string ToString()
        {
            return String.Format("(geoChatMessageEmpty chat_id:{0} id:{1})", chat_id, id);
        }
    }
}