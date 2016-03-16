using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class UserRequestConstructor : User
    {
        public int id;
        public string first_name;
        public string last_name;
        public long access_hash;
        public string phone;
        public UserProfilePhoto photo;
        public UserStatus status;

        public UserRequestConstructor()
        {

        }

        public UserRequestConstructor(int id, string first_name, string last_name, long access_hash, string phone,
            UserProfilePhoto photo, UserStatus status)
        {
            this.id = id;
            this.first_name = first_name;
            this.last_name = last_name;
            this.access_hash = access_hash;
            this.phone = phone;
            this.photo = photo;
            this.status = status;
        }


        public Constructor Constructor
        {
            get { return Constructor.userRequest; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x22e8ceb0);
            writer.Write(this.id);
            Serializers.String.write(writer, this.first_name);
            Serializers.String.write(writer, this.last_name);
            writer.Write(this.access_hash);
            Serializers.String.write(writer, this.phone);
            this.photo.Write(writer);
            this.status.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            this.id = reader.ReadInt32();
            this.first_name = Serializers.String.read(reader);
            this.last_name = Serializers.String.read(reader);
            this.access_hash = reader.ReadInt64();
            this.phone = Serializers.String.read(reader);
            this.photo = Tl.Parse<UserProfilePhoto>(reader);
            this.status = Tl.Parse<UserStatus>(reader);
        }

        public override string ToString()
        {
            return
                String.Format(
                    "(userRequest id:{0} first_name:'{1}' last_name:'{2}' access_hash:{3} phone:'{4}' photo:{5} status:{6})", id,
                    first_name, last_name, access_hash, phone, photo, status);
        }
    }
}