using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class Storage_fileMp4Constructor : storage_FileType
    {

        public Storage_fileMp4Constructor()
        {

        }



        public Constructor Constructor
        {
            get { return Constructor.storage_fileMp4; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xb3cea0e4);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return String.Format("(storage_fileMp4)");
        }
    }
}