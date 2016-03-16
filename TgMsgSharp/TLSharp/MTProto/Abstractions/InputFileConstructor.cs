using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class InputFileConstructor : InputFile
    {
        public long id;
        public int parts;
        public string name;
        public string md5_checksum;

        public InputFileConstructor()
        {

        }

        public InputFileConstructor(long id, int parts, string name, string md5_checksum)
        {
            this.id = id;
            this.parts = parts;
            this.name = name;
            this.md5_checksum = md5_checksum;
        }


        public Constructor Constructor
        {
            get { return Constructor.inputFile; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xf52ff27f);
            writer.Write(this.id);
            writer.Write(this.parts);
            Serializers.String.write(writer, this.name);
            Serializers.String.write(writer, this.md5_checksum);
        }

        public override void Read(BinaryReader reader)
        {
            this.id = reader.ReadInt64();
            this.parts = reader.ReadInt32();
            this.name = Serializers.String.read(reader);
            this.md5_checksum = Serializers.String.read(reader);
        }

        public override string ToString()
        {
            return String.Format("(inputFile id:{0} parts:{1} name:'{2}' md5_checksum:'{3}')", id, parts, name, md5_checksum);
        }
    }
}