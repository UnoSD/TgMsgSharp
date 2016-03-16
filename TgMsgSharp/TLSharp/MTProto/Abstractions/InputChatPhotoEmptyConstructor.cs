using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class InputChatPhotoEmptyConstructor : InputChatPhoto
    {

        public InputChatPhotoEmptyConstructor()
        {

        }



        public Constructor Constructor
        {
            get { return Constructor.inputChatPhotoEmpty; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x1ca48f57);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return String.Format("(inputChatPhotoEmpty)");
        }
    }
}