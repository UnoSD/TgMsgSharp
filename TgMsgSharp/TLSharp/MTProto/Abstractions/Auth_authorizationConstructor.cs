using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class Auth_authorizationConstructor : auth_Authorization
    {
        public int expires;
        public User user;

        public Auth_authorizationConstructor()
        {

        }

        public Auth_authorizationConstructor(int expires, User user)
        {
            this.expires = expires;
            this.user = user;
        }


        public Constructor Constructor
        {
            get { return Constructor.auth_authorization; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xf6b673a4);
            writer.Write(this.expires);
            this.user.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            this.expires = reader.ReadInt32();
            this.user = Tl.Parse<User>(reader);
        }

        public override string ToString()
        {
            return String.Format("(auth_authorization expires:{0} user:{1})", expires, user);
        }
    }
}