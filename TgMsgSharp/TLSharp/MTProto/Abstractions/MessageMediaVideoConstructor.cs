using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class MessageMediaVideoConstructor : MessageMedia
    {
        public Video video;

        public MessageMediaVideoConstructor()
        {

        }

        public MessageMediaVideoConstructor(Video video)
        {
            this.video = video;
        }


        public Constructor Constructor
        {
            get { return Constructor.messageMediaVideo; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xa2d24290);
            this.video.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            this.video = Tl.Parse<Video>(reader);
        }

        public override string ToString()
        {
            return String.Format("(messageMediaVideo video:{0})", video);
        }
    }
}