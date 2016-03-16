using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class UpdateMessageIDConstructor : Update
    {
        public int id;
        public long random_id;

        public UpdateMessageIDConstructor()
        {

        }

        public UpdateMessageIDConstructor(int id, long random_id)
        {
            this.id = id;
            this.random_id = random_id;
        }


        public Constructor Constructor
        {
            get { return Constructor.updateMessageID; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x4e90bfd6);
            writer.Write(this.id);
            writer.Write(this.random_id);
        }

        public override void Read(BinaryReader reader)
        {
            this.id = reader.ReadInt32();
            this.random_id = reader.ReadInt64();
        }

        public override string ToString()
        {
            return String.Format("(updateMessageID id:{0} random_id:{1})", id, random_id);
        }
    }
}