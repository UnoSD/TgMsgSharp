using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class Contacts_foreignLinkUnknownConstructor : contacts_ForeignLink
    {

        public Contacts_foreignLinkUnknownConstructor()
        {

        }



        public Constructor Constructor
        {
            get { return Constructor.contacts_foreignLinkUnknown; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x133421f8);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return String.Format("(contacts_foreignLinkUnknown)");
        }
    }
}