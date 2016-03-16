using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class InputNotifyGeoChatPeerConstructor : InputNotifyPeer
    {
        public InputGeoChat peer;

        public InputNotifyGeoChatPeerConstructor()
        {

        }

        public InputNotifyGeoChatPeerConstructor(InputGeoChat peer)
        {
            this.peer = peer;
        }


        public Constructor Constructor
        {
            get { return Constructor.inputNotifyGeoChatPeer; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x4d8ddec8);
            this.peer.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            this.peer = Tl.Parse<InputGeoChat>(reader);
        }

        public override string ToString()
        {
            return String.Format("(inputNotifyGeoChatPeer peer:{0})", peer);
        }
    }
}