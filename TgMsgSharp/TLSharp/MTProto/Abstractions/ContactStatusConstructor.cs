using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class ContactStatusConstructor : ContactStatus
    {
        public int user_id;
        public int expires;

        public ContactStatusConstructor()
        {

        }

        public ContactStatusConstructor(int user_id, int expires)
        {
            this.user_id = user_id;
            this.expires = expires;
        }


        public Constructor Constructor
        {
            get { return Constructor.contactStatus; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xaa77b873);
            writer.Write(this.user_id);
            writer.Write(this.expires);
        }

        public override void Read(BinaryReader reader)
        {
            this.user_id = reader.ReadInt32();
            this.expires = reader.ReadInt32();
        }

        public override string ToString()
        {
            return String.Format("(contactStatus user_id:{0} expires:{1})", user_id, expires);
        }
    }
}