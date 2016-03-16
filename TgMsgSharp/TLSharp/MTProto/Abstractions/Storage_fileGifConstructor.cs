using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class Storage_fileGifConstructor : storage_FileType
    {

        public Storage_fileGifConstructor()
        {

        }



        public Constructor Constructor
        {
            get { return Constructor.storage_fileGif; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xcae1aadf);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return String.Format("(storage_fileGif)");
        }
    }
}