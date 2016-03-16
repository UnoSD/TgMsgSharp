using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class Messages_messageEmptyConstructor : messages_Message
    {

        public Messages_messageEmptyConstructor()
        {

        }



        public Constructor Constructor
        {
            get { return Constructor.messages_messageEmpty; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x3f4e0648);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return String.Format("(messages_messageEmpty)");
        }
    }
}