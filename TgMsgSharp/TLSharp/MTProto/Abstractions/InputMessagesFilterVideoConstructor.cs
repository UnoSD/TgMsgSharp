using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class InputMessagesFilterVideoConstructor : MessagesFilter
    {

        public InputMessagesFilterVideoConstructor()
        {

        }



        public Constructor Constructor
        {
            get { return Constructor.inputMessagesFilterVideo; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x9fc00e65);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return String.Format("(inputMessagesFilterVideo)");
        }
    }
}