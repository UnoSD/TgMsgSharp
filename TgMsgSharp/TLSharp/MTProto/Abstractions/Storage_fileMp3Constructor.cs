using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class Storage_fileMp3Constructor : storage_FileType
    {

        public Storage_fileMp3Constructor()
        {

        }



        public Constructor Constructor
        {
            get { return Constructor.storage_fileMp3; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x528a0677);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return String.Format("(storage_fileMp3)");
        }
    }
}