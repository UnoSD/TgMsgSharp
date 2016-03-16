using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class Storage_fileJpegConstructor : storage_FileType
    {

        public Storage_fileJpegConstructor()
        {

        }



        public Constructor Constructor
        {
            get { return Constructor.storage_fileJpeg; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x007efe0e);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return String.Format("(storage_fileJpeg)");
        }
    }
}