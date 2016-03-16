using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class Auth_sentCodeConstructor : auth_SentCode
    {
        public bool phone_registered;
        public string phone_code_hash;

        public Auth_sentCodeConstructor()
        {

        }

        public Auth_sentCodeConstructor(bool phone_registered, string phone_code_hash)
        {
            this.phone_registered = phone_registered;
            this.phone_code_hash = phone_code_hash;
        }


        public Constructor Constructor
        {
            get { return Constructor.auth_sentCode; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x2215bcbd);
            writer.Write(this.phone_registered ? 0x997275b5 : 0xbc799737);
            Serializers.String.write(writer, this.phone_code_hash);
        }

        public override void Read(BinaryReader reader)
        {
            this.phone_registered = reader.ReadUInt32() == 0x997275b5;
            this.phone_code_hash = Serializers.String.read(reader);
        }

        public override string ToString()
        {
            return String.Format("(auth_sentCode phone_registered:{0} phone_code_hash:'{1}')", phone_registered, phone_code_hash);
        }
    }
}