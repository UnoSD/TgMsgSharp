using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class InputPeerSelfConstructor : InputPeer
    {

        public InputPeerSelfConstructor()
        {

        }



        public Constructor Constructor
        {
            get { return Constructor.inputPeerSelf; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x7da07ec9);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return String.Format("(inputPeerSelf)");
        }
    }
}