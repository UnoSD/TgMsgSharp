using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class InputUserEmptyConstructor : InputUser
    {

        public InputUserEmptyConstructor()
        {

        }



        public Constructor Constructor
        {
            get { return Constructor.inputUserEmpty; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xb98886cf);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return String.Format("(inputUserEmpty)");
        }
    }
}