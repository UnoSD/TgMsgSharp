using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class PeerNotifyEventsEmptyConstructor : PeerNotifyEvents
    {

        public PeerNotifyEventsEmptyConstructor()
        {

        }



        public Constructor Constructor
        {
            get { return Constructor.peerNotifyEventsEmpty; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xadd53cb3);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return String.Format("(peerNotifyEventsEmpty)");
        }
    }
}