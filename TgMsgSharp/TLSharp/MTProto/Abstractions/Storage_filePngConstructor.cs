using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class Storage_filePngConstructor : storage_FileType
    {

        public Storage_filePngConstructor()
        {

        }



        public Constructor Constructor
        {
            get { return Constructor.storage_filePng; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x0a4f63c0);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return String.Format("(storage_filePng)");
        }
    }
}