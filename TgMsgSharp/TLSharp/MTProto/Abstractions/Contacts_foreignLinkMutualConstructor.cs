using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class Contacts_foreignLinkMutualConstructor : contacts_ForeignLink
    {

        public Contacts_foreignLinkMutualConstructor()
        {

        }



        public Constructor Constructor
        {
            get { return Constructor.contacts_foreignLinkMutual; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x1bea8ce1);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return String.Format("(contacts_foreignLinkMutual)");
        }
    }
}