using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class InputMessagesFilterEmptyConstructor : MessagesFilter
    {

        public InputMessagesFilterEmptyConstructor()
        {

        }



        public Constructor Constructor
        {
            get { return Constructor.inputMessagesFilterEmpty; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x57e2f66c);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return String.Format("(inputMessagesFilterEmpty)");
        }
    }
}