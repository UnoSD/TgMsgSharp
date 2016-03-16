using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class InputNotifyPeerConstructor : InputNotifyPeer
    {
        public InputPeer peer;

        public InputNotifyPeerConstructor()
        {

        }

        public InputNotifyPeerConstructor(InputPeer peer)
        {
            this.peer = peer;
        }


        public Constructor Constructor
        {
            get { return Constructor.inputNotifyPeer; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xb8bc5b0c);
            this.peer.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            this.peer = Tl.Parse<InputPeer>(reader);
        }

        public override string ToString()
        {
            return String.Format("(inputNotifyPeer peer:{0})", peer);
        }
    }
}