using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class UpdateUserPhotoConstructor : Update
    {
        public int user_id;
        public int date;
        public UserProfilePhoto photo;
        public bool previous;

        public UpdateUserPhotoConstructor()
        {

        }

        public UpdateUserPhotoConstructor(int user_id, int date, UserProfilePhoto photo, bool previous)
        {
            this.user_id = user_id;
            this.date = date;
            this.photo = photo;
            this.previous = previous;
        }


        public Constructor Constructor
        {
            get { return Constructor.updateUserPhoto; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x95313b0c);
            writer.Write(this.user_id);
            writer.Write(this.date);
            this.photo.Write(writer);
            writer.Write(this.previous ? 0x997275b5 : 0xbc799737);
        }

        public override void Read(BinaryReader reader)
        {
            this.user_id = reader.ReadInt32();
            this.date = reader.ReadInt32();
            this.photo = Tl.Parse<UserProfilePhoto>(reader);
            this.previous = reader.ReadUInt32() == 0x997275b5;
        }

        public override string ToString()
        {
            return String.Format("(updateUserPhoto user_id:{0} date:{1} photo:{2} previous:{3})", user_id, date, photo, previous);
        }
    }
}