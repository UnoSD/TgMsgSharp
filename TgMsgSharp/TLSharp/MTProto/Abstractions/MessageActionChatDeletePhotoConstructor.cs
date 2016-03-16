using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class MessageActionChatDeletePhotoConstructor : MessageAction
    {

        public MessageActionChatDeletePhotoConstructor()
        {

        }



        public Constructor Constructor
        {
            get { return Constructor.messageActionChatDeletePhoto; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x95e3fbef);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return String.Format("(messageActionChatDeletePhoto)");
        }
    }
}