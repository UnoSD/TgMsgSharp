using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class UserProfilePhotoEmptyConstructor : UserProfilePhoto
    {

        public UserProfilePhotoEmptyConstructor()
        {

        }



        public Constructor Constructor
        {
            get { return Constructor.userProfilePhotoEmpty; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x4f11bae1);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return String.Format("(userProfilePhotoEmpty)");
        }
    }
}