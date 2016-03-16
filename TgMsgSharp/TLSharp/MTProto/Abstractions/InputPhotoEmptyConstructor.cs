using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class InputPhotoEmptyConstructor : InputPhoto
    {

        public InputPhotoEmptyConstructor()
        {

        }



        public Constructor Constructor
        {
            get { return Constructor.inputPhotoEmpty; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x1cd7bf0d);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return String.Format("(inputPhotoEmpty)");
        }
    }
}