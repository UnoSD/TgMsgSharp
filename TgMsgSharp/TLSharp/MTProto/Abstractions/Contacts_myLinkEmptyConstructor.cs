using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class Contacts_myLinkEmptyConstructor : contacts_MyLink
    {

        public Contacts_myLinkEmptyConstructor()
        {

        }



        public Constructor Constructor
        {
            get { return Constructor.contacts_myLinkEmpty; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xd22a1c60);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return String.Format("(contacts_myLinkEmpty)");
        }
    }
}