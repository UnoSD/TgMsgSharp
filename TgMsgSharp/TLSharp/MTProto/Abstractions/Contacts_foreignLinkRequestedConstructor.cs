using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class Contacts_foreignLinkRequestedConstructor : contacts_ForeignLink
    {
        public bool has_phone;

        public Contacts_foreignLinkRequestedConstructor()
        {

        }

        public Contacts_foreignLinkRequestedConstructor(bool has_phone)
        {
            this.has_phone = has_phone;
        }


        public Constructor Constructor
        {
            get { return Constructor.contacts_foreignLinkRequested; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xa7801f47);
            writer.Write(this.has_phone ? 0x997275b5 : 0xbc799737);
        }

        public override void Read(BinaryReader reader)
        {
            this.has_phone = reader.ReadUInt32() == 0x997275b5;
        }

        public override string ToString()
        {
            return String.Format("(contacts_foreignLinkRequested has_phone:{0})", has_phone);
        }
    }
}