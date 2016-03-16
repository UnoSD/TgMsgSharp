using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class UpdatesTooLongConstructor : Updates
    {

        public UpdatesTooLongConstructor()
        {

        }



        public Constructor Constructor
        {
            get { return Constructor.updatesTooLong; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xe317af7e);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return String.Format("(updatesTooLong)");
        }
    }
}