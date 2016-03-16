using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class Auth_exportedAuthorizationConstructor : auth_ExportedAuthorization
    {
        public int id;
        public byte[] bytes;

        public Auth_exportedAuthorizationConstructor()
        {

        }

        public Auth_exportedAuthorizationConstructor(int id, byte[] bytes)
        {
            this.id = id;
            this.bytes = bytes;
        }


        public Constructor Constructor
        {
            get { return Constructor.auth_exportedAuthorization; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xdf969c2d);
            writer.Write(this.id);
            Serializers.Bytes.write(writer, this.bytes);
        }

        public override void Read(BinaryReader reader)
        {
            this.id = reader.ReadInt32();
            this.bytes = Serializers.Bytes.read(reader);
        }

        public override string ToString()
        {
            return String.Format("(auth_exportedAuthorization id:{0} bytes:{1})", id, BitConverter.ToString(bytes));
        }
    }
}