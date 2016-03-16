using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class InputMessagesFilterPhotosConstructor : MessagesFilter
    {

        public InputMessagesFilterPhotosConstructor()
        {

        }



        public Constructor Constructor
        {
            get { return Constructor.inputMessagesFilterPhotos; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x9609a51c);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return String.Format("(inputMessagesFilterPhotos)");
        }
    }
}