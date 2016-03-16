using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class Storage_fileWebpConstructor : storage_FileType
    {

        public Storage_fileWebpConstructor()
        {

        }



        public Constructor Constructor
        {
            get { return Constructor.storage_fileWebp; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x1081464c);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return String.Format("(storage_fileWebp)");
        }
    }
}