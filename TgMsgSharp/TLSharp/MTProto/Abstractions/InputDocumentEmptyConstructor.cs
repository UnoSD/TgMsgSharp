using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class InputDocumentEmptyConstructor : InputDocument
    {

        public InputDocumentEmptyConstructor()
        {

        }



        public Constructor Constructor
        {
            get { return Constructor.inputDocumentEmpty; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x72f0eaae);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return String.Format("(inputDocumentEmpty)");
        }
    }
}