using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class Upload_fileConstructor : upload_File
    {
        public storage_FileType type;
        public int mtime;
        public byte[] bytes;

        public Upload_fileConstructor()
        {

        }

        public Upload_fileConstructor(storage_FileType type, int mtime, byte[] bytes)
        {
            this.type = type;
            this.mtime = mtime;
            this.bytes = bytes;
        }


        public Constructor Constructor
        {
            get { return Constructor.upload_file; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x096a18d5);
            this.type.Write(writer);
            writer.Write(this.mtime);
            Serializers.Bytes.write(writer, this.bytes);
        }

        public override void Read(BinaryReader reader)
        {
            this.type = Tl.Parse<storage_FileType>(reader);
            this.mtime = reader.ReadInt32();
            this.bytes = Serializers.Bytes.read(reader);
        }

        public override string ToString()
        {
            return String.Format("(upload_file type:{0} mtime:{1} bytes:{2})", type, mtime, BitConverter.ToString(bytes));
        }
    }
}