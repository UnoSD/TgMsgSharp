using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class InputChatPhotoConstructor : InputChatPhoto
    {
        public InputPhoto id;
        public InputPhotoCrop crop;

        public InputChatPhotoConstructor()
        {

        }

        public InputChatPhotoConstructor(InputPhoto id, InputPhotoCrop crop)
        {
            this.id = id;
            this.crop = crop;
        }


        public Constructor Constructor
        {
            get { return Constructor.inputChatPhoto; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xb2e1bf08);
            this.id.Write(writer);
            this.crop.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            this.id = Tl.Parse<InputPhoto>(reader);
            this.crop = Tl.Parse<InputPhotoCrop>(reader);
        }

        public override string ToString()
        {
            return String.Format("(inputChatPhoto id:{0} crop:{1})", id, crop);
        }
    }
}