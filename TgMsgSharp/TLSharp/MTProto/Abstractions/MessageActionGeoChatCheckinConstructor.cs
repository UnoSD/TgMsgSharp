using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class MessageActionGeoChatCheckinConstructor : MessageAction
    {

        public MessageActionGeoChatCheckinConstructor()
        {

        }



        public Constructor Constructor
        {
            get { return Constructor.messageActionGeoChatCheckin; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x0c7d53de);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return String.Format("(messageActionGeoChatCheckin)");
        }
    }
}