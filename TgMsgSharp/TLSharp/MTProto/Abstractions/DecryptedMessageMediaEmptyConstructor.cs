using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class DecryptedMessageMediaEmptyConstructor : DecryptedMessageMedia
    {

        public DecryptedMessageMediaEmptyConstructor()
        {

        }



        public Constructor Constructor
        {
            get { return Constructor.decryptedMessageMediaEmpty; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x089f5c4a);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return String.Format("(decryptedMessageMediaEmpty)");
        }
    }
}