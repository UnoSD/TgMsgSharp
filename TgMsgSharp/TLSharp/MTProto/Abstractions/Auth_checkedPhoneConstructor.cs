using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class Auth_checkedPhoneConstructor : auth_CheckedPhone
    {
        public bool phone_registered;
        public bool phone_invited;

        public Auth_checkedPhoneConstructor()
        {

        }

        public Auth_checkedPhoneConstructor(bool phone_registered, bool phone_invited)
        {
            this.phone_registered = phone_registered;
            this.phone_invited = phone_invited;
        }


        public Constructor Constructor
        {
            get { return Constructor.auth_checkedPhone; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xe300cc3b);
            writer.Write(this.phone_registered ? 0x997275b5 : 0xbc799737);
            writer.Write(this.phone_invited ? 0x997275b5 : 0xbc799737);
        }

        public override void Read(BinaryReader reader)
        {
            this.phone_registered = reader.ReadUInt32() == 0x997275b5;
            this.phone_invited = reader.ReadUInt32() == 0x997275b5;
        }

        public override string ToString()
        {
            return String.Format("(auth_checkedPhone phone_registered:{0} phone_invited:{1})", phone_registered, phone_invited);
        }
    }
}