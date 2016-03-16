using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class MessageEmptyConstructor : Message
    {
        public int id;

        public MessageEmptyConstructor()
        {

        }

        public MessageEmptyConstructor(int id)
        {
            this.id = id;
        }


        public Constructor Constructor
        {
            get { return Constructor.messageEmpty; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x83e5de54);
            writer.Write(this.id);
        }

        public override void Read(BinaryReader reader)
        {
            this.id = reader.ReadInt32();
        }

        public override string ToString()
        {
            return String.Format("(messageEmpty id:{0})", id);
        }
    }
}