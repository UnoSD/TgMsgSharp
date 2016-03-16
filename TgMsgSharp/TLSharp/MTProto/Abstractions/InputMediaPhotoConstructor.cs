using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class InputMediaPhotoConstructor : InputMedia
    {
        public InputPhoto id;

        public InputMediaPhotoConstructor()
        {

        }

        public InputMediaPhotoConstructor(InputPhoto id)
        {
            this.id = id;
        }


        public Constructor Constructor
        {
            get { return Constructor.inputMediaPhoto; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x8f2ab2ec);
            this.id.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            this.id = Tl.Parse<InputPhoto>(reader);
        }

        public override string ToString()
        {
            return String.Format("(inputMediaPhoto id:{0})", id);
        }
    }
}