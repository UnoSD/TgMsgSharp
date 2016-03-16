using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class MessageActionEmptyConstructor : MessageAction
    {

        public MessageActionEmptyConstructor()
        {

        }



        public Constructor Constructor
        {
            get { return Constructor.messageActionEmpty; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xb6aef7b0);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return String.Format("(messageActionEmpty)");
        }
    }
}