using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class InputChatUploadedPhotoConstructor : InputChatPhoto
    {
        public InputFile file;
        public InputPhotoCrop crop;

        public InputChatUploadedPhotoConstructor()
        {

        }

        public InputChatUploadedPhotoConstructor(InputFile file, InputPhotoCrop crop)
        {
            this.file = file;
            this.crop = crop;
        }


        public Constructor Constructor
        {
            get { return Constructor.inputChatUploadedPhoto; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x94254732);
            this.file.Write(writer);
            this.crop.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            this.file = Tl.Parse<InputFile>(reader);
            this.crop = Tl.Parse<InputPhotoCrop>(reader);
        }

        public override string ToString()
        {
            return String.Format("(inputChatUploadedPhoto file:{0} crop:{1})", file, crop);
        }
    }
}