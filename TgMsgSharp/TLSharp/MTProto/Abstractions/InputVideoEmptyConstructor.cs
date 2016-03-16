using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class InputVideoEmptyConstructor : InputVideo
    {

        public InputVideoEmptyConstructor()
        {

        }



        public Constructor Constructor
        {
            get { return Constructor.inputVideoEmpty; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x5508ec75);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return String.Format("(inputVideoEmpty)");
        }
    }
}