using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class InputPhotoCropAutoConstructor : InputPhotoCrop
    {

        public InputPhotoCropAutoConstructor()
        {

        }



        public Constructor Constructor
        {
            get { return Constructor.inputPhotoCropAuto; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xade6b004);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return String.Format("(inputPhotoCropAuto)");
        }
    }
}