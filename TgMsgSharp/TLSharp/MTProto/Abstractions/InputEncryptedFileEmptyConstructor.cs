using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class InputEncryptedFileEmptyConstructor : InputEncryptedFile
    {

        public InputEncryptedFileEmptyConstructor()
        {

        }



        public Constructor Constructor
        {
            get { return Constructor.inputEncryptedFileEmpty; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x1837c364);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return String.Format("(inputEncryptedFileEmpty)");
        }
    }
}