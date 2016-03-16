using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class ContactConstructor : Contact
    {
        public int user_id;
        public bool mutual;

        public ContactConstructor()
        {

        }

        public ContactConstructor(int user_id, bool mutual)
        {
            this.user_id = user_id;
            this.mutual = mutual;
        }


        public Constructor Constructor
        {
            get { return Constructor.contact; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xf911c994);
            writer.Write(this.user_id);
            writer.Write(this.mutual ? 0x997275b5 : 0xbc799737);
        }

        public override void Read(BinaryReader reader)
        {
            this.user_id = reader.ReadInt32();
            this.mutual = reader.ReadUInt32() == 0x997275b5;
        }

        public override string ToString()
        {
            return String.Format("(contact user_id:{0} mutual:{1})", user_id, mutual);
        }
    }
}