using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class MessageActionChatEditPhotoConstructor : MessageAction
    {
        public Photo photo;

        public MessageActionChatEditPhotoConstructor()
        {

        }

        public MessageActionChatEditPhotoConstructor(Photo photo)
        {
            this.photo = photo;
        }


        public Constructor Constructor
        {
            get { return Constructor.messageActionChatEditPhoto; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x7fcb13a8);
            this.photo.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            this.photo = Tl.Parse<Photo>(reader);
        }

        public override string ToString()
        {
            return String.Format("(messageActionChatEditPhoto photo:{0})", photo);
        }
    }
}