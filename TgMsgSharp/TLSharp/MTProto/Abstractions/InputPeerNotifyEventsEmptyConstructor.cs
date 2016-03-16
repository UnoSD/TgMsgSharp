using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class InputPeerNotifyEventsEmptyConstructor : InputPeerNotifyEvents
    {

        public InputPeerNotifyEventsEmptyConstructor()
        {

        }



        public Constructor Constructor
        {
            get { return Constructor.inputPeerNotifyEventsEmpty; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xf03064d8);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return String.Format("(inputPeerNotifyEventsEmpty)");
        }
    }
}