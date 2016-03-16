using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class Contacts_myLinkContactConstructor : contacts_MyLink
    {

        public Contacts_myLinkContactConstructor()
        {

        }



        public Constructor Constructor
        {
            get { return Constructor.contacts_myLinkContact; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xc240ebd9);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return String.Format("(contacts_myLinkContact)");
        }
    }
}