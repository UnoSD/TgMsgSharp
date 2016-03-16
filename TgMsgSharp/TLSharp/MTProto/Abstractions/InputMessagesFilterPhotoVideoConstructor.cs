using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class InputMessagesFilterPhotoVideoConstructor : MessagesFilter
    {

        public InputMessagesFilterPhotoVideoConstructor()
        {

        }



        public Constructor Constructor
        {
            get { return Constructor.inputMessagesFilterPhotoVideo; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x56e9f0e4);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return String.Format("(inputMessagesFilterPhotoVideo)");
        }
    }
}