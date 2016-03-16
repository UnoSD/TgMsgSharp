using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class ContactFoundConstructor : ContactFound
    {
        public int user_id;

        public ContactFoundConstructor()
        {

        }

        public ContactFoundConstructor(int user_id)
        {
            this.user_id = user_id;
        }


        public Constructor Constructor
        {
            get { return Constructor.contactFound; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xea879f95);
            writer.Write(this.user_id);
        }

        public override void Read(BinaryReader reader)
        {
            this.user_id = reader.ReadInt32();
        }

        public override string ToString()
        {
            return String.Format("(contactFound user_id:{0})", user_id);
        }
    }
}