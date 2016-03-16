using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class InputMediaUploadedThumbVideoConstructor : InputMedia
    {
        public InputFile file;
        public InputFile thumb;
        public int duration;
        public int w;
        public int h;

        public InputMediaUploadedThumbVideoConstructor()
        {

        }

        public InputMediaUploadedThumbVideoConstructor(InputFile file, InputFile thumb, int duration, int w, int h)
        {
            this.file = file;
            this.thumb = thumb;
            this.duration = duration;
            this.w = w;
            this.h = h;
        }


        public Constructor Constructor
        {
            get { return Constructor.inputMediaUploadedThumbVideo; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xe628a145);
            this.file.Write(writer);
            this.thumb.Write(writer);
            writer.Write(this.duration);
            writer.Write(this.w);
            writer.Write(this.h);
        }

        public override void Read(BinaryReader reader)
        {
            this.file = Tl.Parse<InputFile>(reader);
            this.thumb = Tl.Parse<InputFile>(reader);
            this.duration = reader.ReadInt32();
            this.w = reader.ReadInt32();
            this.h = reader.ReadInt32();
        }

        public override string ToString()
        {
            return String.Format("(inputMediaUploadedThumbVideo file:{0} thumb:{1} duration:{2} w:{3} h:{4})", file, thumb,
                duration, w, h);
        }
    }
}