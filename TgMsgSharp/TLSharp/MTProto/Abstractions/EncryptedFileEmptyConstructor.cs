using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class EncryptedFileEmptyConstructor : EncryptedFile
    {

        public EncryptedFileEmptyConstructor()
        {

        }



        public Constructor Constructor
        {
            get { return Constructor.encryptedFileEmpty; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xc21f497e);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return String.Format("(encryptedFileEmpty)");
        }
    }
}