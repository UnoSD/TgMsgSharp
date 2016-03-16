using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class ContactBlockedConstructor : ContactBlocked
    {
        public int user_id;
        public int date;

        public ContactBlockedConstructor()
        {

        }

        public ContactBlockedConstructor(int user_id, int date)
        {
            this.user_id = user_id;
            this.date = date;
        }


        public Constructor Constructor
        {
            get { return Constructor.contactBlocked; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x561bc879);
            writer.Write(this.user_id);
            writer.Write(this.date);
        }

        public override void Read(BinaryReader reader)
        {
            this.user_id = reader.ReadInt32();
            this.date = reader.ReadInt32();
        }

        public override string ToString()
        {
            return String.Format("(contactBlocked user_id:{0} date:{1})", user_id, date);
        }
    }
}