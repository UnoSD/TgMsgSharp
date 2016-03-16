using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class InputPeerNotifyEventsAllConstructor : InputPeerNotifyEvents
    {

        public InputPeerNotifyEventsAllConstructor()
        {

        }



        public Constructor Constructor
        {
            get { return Constructor.inputPeerNotifyEventsAll; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xe86a2c74);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return String.Format("(inputPeerNotifyEventsAll)");
        }
    }
}