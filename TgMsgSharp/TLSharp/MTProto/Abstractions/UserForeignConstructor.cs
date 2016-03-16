using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class UserForeignConstructor : User
    {
        public int id;
        public string first_name;
        public string last_name;
        public long access_hash;
        public UserProfilePhoto photo;
        public UserStatus status;

        public UserForeignConstructor()
        {

        }

        public UserForeignConstructor(int id, string first_name, string last_name, long access_hash, UserProfilePhoto photo,
            UserStatus status)
        {
            this.id = id;
            this.first_name = first_name;
            this.last_name = last_name;
            this.access_hash = access_hash;
            this.photo = photo;
            this.status = status;
        }


        public Constructor Constructor
        {
            get { return Constructor.userForeign; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x5214c89d);
            writer.Write(this.id);
            Serializers.String.write(writer, this.first_name);
            Serializers.String.write(writer, this.last_name);
            writer.Write(this.access_hash);
            this.photo.Write(writer);
            this.status.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            this.id = reader.ReadInt32();
            this.first_name = Serializers.String.read(reader);
            this.last_name = Serializers.String.read(reader);
            this.access_hash = reader.ReadInt64();
            this.photo = Tl.Parse<UserProfilePhoto>(reader);
            this.status = Tl.Parse<UserStatus>(reader);
        }

        public override string ToString()
        {
            return String.Format("(userForeign id:{0} first_name:'{1}' last_name:'{2}' access_hash:{3} photo:{4} status:{5})", id,
                first_name, last_name, access_hash, photo, status);
        }
    }
}