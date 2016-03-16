using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class InputMediaUploadedPhotoConstructor : InputMedia
    {
        public InputFile file;

        public InputMediaUploadedPhotoConstructor()
        {

        }

        public InputMediaUploadedPhotoConstructor(InputFile file)
        {
            this.file = file;
        }


        public Constructor Constructor
        {
            get { return Constructor.inputMediaUploadedPhoto; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x2dc53a7d);
            this.file.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            this.file = Tl.Parse<InputFile>(reader);
        }

        public override string ToString()
        {
            return String.Format("(inputMediaUploadedPhoto file:{0})", file);
        }
    }
}