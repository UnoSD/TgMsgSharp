using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class Storage_fileMovConstructor : storage_FileType
    {

        public Storage_fileMovConstructor()
        {

        }



        public Constructor Constructor
        {
            get { return Constructor.storage_fileMov; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x4b09ebbc);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return String.Format("(storage_fileMov)");
        }
    }
}