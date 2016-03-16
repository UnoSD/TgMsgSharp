using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class Contacts_myLinkRequestedConstructor : contacts_MyLink
    {
        public bool contact;

        public Contacts_myLinkRequestedConstructor()
        {

        }

        public Contacts_myLinkRequestedConstructor(bool contact)
        {
            this.contact = contact;
        }


        public Constructor Constructor
        {
            get { return Constructor.contacts_myLinkRequested; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x6c69efee);
            writer.Write(this.contact ? 0x997275b5 : 0xbc799737);
        }

        public override void Read(BinaryReader reader)
        {
            this.contact = reader.ReadUInt32() == 0x997275b5;
        }

        public override string ToString()
        {
            return String.Format("(contacts_myLinkRequested contact:{0})", contact);
        }
    }
}