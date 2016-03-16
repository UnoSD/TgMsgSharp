using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class UserFullConstructor : UserFull
    {
        public User user;
        public contacts_Link link;
        public Photo profile_photo;
        public PeerNotifySettings notify_settings;
        public bool blocked;
        public string real_first_name;
        public string real_last_name;

        public UserFullConstructor()
        {

        }

        public UserFullConstructor(User user, contacts_Link link, Photo profile_photo, PeerNotifySettings notify_settings,
            bool blocked, string real_first_name, string real_last_name)
        {
            this.user = user;
            this.link = link;
            this.profile_photo = profile_photo;
            this.notify_settings = notify_settings;
            this.blocked = blocked;
            this.real_first_name = real_first_name;
            this.real_last_name = real_last_name;
        }


        public Constructor Constructor
        {
            get { return Constructor.userFull; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x771095da);
            this.user.Write(writer);
            this.link.Write(writer);
            this.profile_photo.Write(writer);
            this.notify_settings.Write(writer);
            writer.Write(this.blocked ? 0x997275b5 : 0xbc799737);
            Serializers.String.write(writer, this.real_first_name);
            Serializers.String.write(writer, this.real_last_name);
        }

        public override void Read(BinaryReader reader)
        {
            this.user = Tl.Parse<User>(reader);
            this.link = Tl.Parse<contacts_Link>(reader);
            this.profile_photo = Tl.Parse<Photo>(reader);
            this.notify_settings = Tl.Parse<PeerNotifySettings>(reader);
            this.blocked = reader.ReadUInt32() == 0x997275b5;
            this.real_first_name = Serializers.String.read(reader);
            this.real_last_name = Serializers.String.read(reader);
        }

        public override string ToString()
        {
            return
                String.Format(
                    "(userFull user:{0} link:{1} profile_photo:{2} notify_settings:{3} blocked:{4} real_first_name:'{5}' real_last_name:'{6}')",
                    user, link, profile_photo, notify_settings, blocked, real_first_name, real_last_name);
        }
    }
}