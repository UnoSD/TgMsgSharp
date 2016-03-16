using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class ChatPhotoConstructor : ChatPhoto
    {
        public FileLocation photo_small;
        public FileLocation photo_big;

        public ChatPhotoConstructor()
        {

        }

        public ChatPhotoConstructor(FileLocation photo_small, FileLocation photo_big)
        {
            this.photo_small = photo_small;
            this.photo_big = photo_big;
        }


        public Constructor Constructor
        {
            get { return Constructor.chatPhoto; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x6153276a);
            this.photo_small.Write(writer);
            this.photo_big.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            this.photo_small = Tl.Parse<FileLocation>(reader);
            this.photo_big = Tl.Parse<FileLocation>(reader);
        }

        public override string ToString()
        {
            return String.Format("(chatPhoto photo_small:{0} photo_big:{1})", photo_small, photo_big);
        }
    }
}