using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class UserContactConstructor : User
    {
        public static Combinator Combinator => new Combinator(0xcab35e18);

        public int id;
        public string first_name;
        public string last_name;
        public long access_hash;
        public string phone;
        public UserProfilePhoto photo;
        public UserStatus status;
        
        public override void Write(BinaryWriter writer)
        {
            throw new NotImplementedException();

            writer.Write(0xf2fb8319);
        }

        public override void Read(BinaryReader reader)
        {
            // userContact#cab35e18 id:int first_name:string last_name:string username:string access_hash:long phone:string photo:UserProfilePhoto status:UserStatus = User;

            this.id = reader.ReadInt32();
            this.first_name = Serializers.String.read(reader);
            this.last_name = Serializers.String.read(reader);
            this.Username = Serializers.String.read(reader);
            this.access_hash = reader.ReadInt64();
            this.phone = Serializers.String.read(reader);
            this.photo = Tl.Parse<UserProfilePhoto>(reader);
            this.status = Tl.Parse<UserStatus>(reader);
        }

        public string Username { get; set; }

        public override string ToString()
        {
            return
                String.Format(
                    "(userContact id:{0} first_name:'{1}' last_name:'{2}' access_hash:{3} phone:'{4}' photo:{5} status:{6})", id,
                    first_name, last_name, access_hash, phone, photo, status);
        }
    }
}