using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class InputPeerEmptyConstructor : InputPeer
    {

        public InputPeerEmptyConstructor()
        {

        }



        public Constructor Constructor
        {
            get { return Constructor.inputPeerEmpty; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x7f3b18ea);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return String.Format("(inputPeerEmpty)");
        }
    }
}