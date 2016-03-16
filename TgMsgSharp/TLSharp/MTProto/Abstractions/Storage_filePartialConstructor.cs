using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class Storage_filePartialConstructor : storage_FileType
    {

        public Storage_filePartialConstructor()
        {

        }



        public Constructor Constructor
        {
            get { return Constructor.storage_filePartial; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x40bc6f52);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return String.Format("(storage_filePartial)");
        }
    }
}