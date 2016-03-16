using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class MessageMediaPhotoConstructor : MessageMedia
    {
        public Photo photo;

        public MessageMediaPhotoConstructor()
        {

        }

        public MessageMediaPhotoConstructor(Photo photo)
        {
            this.photo = photo;
        }


        public Constructor Constructor
        {
            get { return Constructor.messageMediaPhoto; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xc8c45a2a);
            this.photo.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            this.photo = Tl.Parse<Photo>(reader);
        }

        public override string ToString()
        {
            return String.Format("(messageMediaPhoto photo:{0})", photo);
        }
    }
}