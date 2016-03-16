using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class VideoEmptyConstructor : Video
    {
        public long id;

        public VideoEmptyConstructor()
        {

        }

        public VideoEmptyConstructor(long id)
        {
            this.id = id;
        }


        public Constructor Constructor
        {
            get { return Constructor.videoEmpty; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xc10658a8);
            writer.Write(this.id);
        }

        public override void Read(BinaryReader reader)
        {
            this.id = reader.ReadInt64();
        }

        public override string ToString()
        {
            return String.Format("(videoEmpty id:{0})", id);
        }
    }
}