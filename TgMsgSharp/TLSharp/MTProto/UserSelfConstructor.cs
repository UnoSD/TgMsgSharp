using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class UserSelfConstructor : User
    {
        public int id;
        public string first_name;
        public string last_name;
        public string phone;
        public UserProfilePhoto photo;
        public UserStatus status;
        public bool inactive;

        public UserSelfConstructor()
        {

        }

        public UserSelfConstructor(int id, string first_name, string last_name, string phone, UserProfilePhoto photo,
            UserStatus status, bool inactive)
        {
            this.id = id;
            this.first_name = first_name;
            this.last_name = last_name;
            this.phone = phone;
            this.photo = photo;
            this.status = status;
            this.inactive = inactive;
        }


        public Constructor Constructor
        {
            get { return Constructor.userSelf; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x720535ec);
            writer.Write(this.id);
            Serializers.String.write(writer, this.first_name);
            Serializers.String.write(writer, this.last_name);
            Serializers.String.write(writer, this.phone);
            //this.photo.Write(writer);
            //this.status.Write(writer);
            writer.Write(this.inactive ? 0x997275b5 : 0xbc799737);
        }

        public override void Read(BinaryReader reader)
        {
            //userSelf#7007b451 id:int first_name:string last_name:string username:string phone:string photo:UserProfilePhoto status:UserStatus inactive:Bool = User;

            this.id = reader.ReadInt32();
            this.first_name = Serializers.String.read(reader);
            this.last_name = Serializers.String.read(reader);
            var userName = Serializers.String.read(reader);
            this.phone = Serializers.String.read(reader);

            //while (true)
            //{
            //    var bla = reader.ReadUInt32();
            //    var hex = new Combinator(bla).ToHex;
            //    var type = new Combinator(bla).ToType;

            //    if (type != null) type.ToString();
            //}
            
            this.photo = Tl.Parse<UserProfilePhoto>(reader);
            this.status = Tl.Parse<UserStatus>(reader);
            this.inactive = reader.ReadUInt32() == 0x997275b5;
        }

        public override string ToString()
        {
            return
                String.Format("(userSelf id:{0} first_name:'{1}' last_name:'{2}' phone:'{3}' photo:{4} status:{5} inactive:{6})", id,
                    first_name, last_name, phone, photo, status, inactive);
        }
    }
}