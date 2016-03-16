using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class PeerNotifyEventsAllConstructor : PeerNotifyEvents
    {

        public PeerNotifyEventsAllConstructor()
        {

        }



        public Constructor Constructor
        {
            get { return Constructor.peerNotifyEventsAll; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x6d1ded88);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return String.Format("(peerNotifyEventsAll)");
        }
    }
}