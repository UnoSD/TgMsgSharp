using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class InputMediaUploadedVideoConstructor : InputMedia
    {
        public InputFile file;
        public int duration;
        public int w;
        public int h;

        public InputMediaUploadedVideoConstructor()
        {

        }

        public InputMediaUploadedVideoConstructor(InputFile file, int duration, int w, int h)
        {
            this.file = file;
            this.duration = duration;
            this.w = w;
            this.h = h;
        }


        public Constructor Constructor
        {
            get { return Constructor.inputMediaUploadedVideo; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x4847d92a);
            this.file.Write(writer);
            writer.Write(this.duration);
            writer.Write(this.w);
            writer.Write(this.h);
        }

        public override void Read(BinaryReader reader)
        {
            this.file = Tl.Parse<InputFile>(reader);
            this.duration = reader.ReadInt32();
            this.w = reader.ReadInt32();
            this.h = reader.ReadInt32();
        }

        public override string ToString()
        {
            return String.Format("(inputMediaUploadedVideo file:{0} duration:{1} w:{2} h:{3})", file, duration, w, h);
        }
    }
}