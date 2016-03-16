using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class UserProfilePhotoConstructor : UserProfilePhoto
    {
        public long photo_id;
        public FileLocation photo_small;
        public FileLocation photo_big;

        public UserProfilePhotoConstructor()
        {

        }

        public UserProfilePhotoConstructor(long photo_id, FileLocation photo_small, FileLocation photo_big)
        {
            this.photo_id = photo_id;
            this.photo_small = photo_small;
            this.photo_big = photo_big;
        }


        public Constructor Constructor
        {
            get { return Constructor.userProfilePhoto; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xd559d8c8);
            writer.Write(this.photo_id);
            this.photo_small.Write(writer);
            this.photo_big.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            this.photo_id = reader.ReadInt64();
            this.photo_small = Tl.Parse<FileLocation>(reader);
            this.photo_big = Tl.Parse<FileLocation>(reader);
        }

        public override string ToString()
        {
            return String.Format("(userProfilePhoto photo_id:{0} photo_small:{1} photo_big:{2})", photo_id, photo_small,
                photo_big);
        }
    }
}