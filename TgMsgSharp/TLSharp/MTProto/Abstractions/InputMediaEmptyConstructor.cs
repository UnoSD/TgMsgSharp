using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class InputMediaEmptyConstructor : InputMedia
    {

        public InputMediaEmptyConstructor()
        {

        }



        public Constructor Constructor
        {
            get { return Constructor.inputMediaEmpty; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x9664f57f);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return String.Format("(inputMediaEmpty)");
        }
    }
}