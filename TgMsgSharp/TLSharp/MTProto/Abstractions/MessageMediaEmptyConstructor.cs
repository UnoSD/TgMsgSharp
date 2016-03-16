using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class MessageMediaEmptyConstructor : MessageMedia
    {

        public MessageMediaEmptyConstructor()
        {

        }



        public Constructor Constructor
        {
            get { return Constructor.messageMediaEmpty; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x3ded6320);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return String.Format("(messageMediaEmpty)");
        }
    }
}