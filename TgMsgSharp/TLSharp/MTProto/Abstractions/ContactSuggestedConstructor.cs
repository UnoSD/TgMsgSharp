using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class ContactSuggestedConstructor : ContactSuggested
    {
        public int user_id;
        public int mutual_contacts;

        public ContactSuggestedConstructor()
        {

        }

        public ContactSuggestedConstructor(int user_id, int mutual_contacts)
        {
            this.user_id = user_id;
            this.mutual_contacts = mutual_contacts;
        }


        public Constructor Constructor
        {
            get { return Constructor.contactSuggested; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x3de191a1);
            writer.Write(this.user_id);
            writer.Write(this.mutual_contacts);
        }

        public override void Read(BinaryReader reader)
        {
            this.user_id = reader.ReadInt32();
            this.mutual_contacts = reader.ReadInt32();
        }

        public override string ToString()
        {
            return String.Format("(contactSuggested user_id:{0} mutual_contacts:{1})", user_id, mutual_contacts);
        }
    }
}