using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class Storage_fileUnknownConstructor : storage_FileType
    {

        public Storage_fileUnknownConstructor()
        {

        }



        public Constructor Constructor
        {
            get { return Constructor.storage_fileUnknown; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xaa963b05);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return String.Format("(storage_fileUnknown)");
        }
    }
}