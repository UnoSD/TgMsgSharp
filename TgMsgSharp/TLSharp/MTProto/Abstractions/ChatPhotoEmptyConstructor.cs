using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class ChatPhotoEmptyConstructor : ChatPhoto
    {

        public ChatPhotoEmptyConstructor()
        {

        }



        public Constructor Constructor
        {
            get { return Constructor.chatPhotoEmpty; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x37c1011c);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return String.Format("(chatPhotoEmpty)");
        }
    }
}