using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class Contacts_contactsNotModifiedConstructor : contacts_Contacts
    {

        public Contacts_contactsNotModifiedConstructor()
        {

        }



        public Constructor Constructor
        {
            get { return Constructor.contacts_contactsNotModified; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xb74ba9d2);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return String.Format("(contacts_contactsNotModified)");
        }
    }
}