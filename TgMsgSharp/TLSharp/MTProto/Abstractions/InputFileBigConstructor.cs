using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class InputFileBigConstructor : InputFile
    {
        public long id;
        public int parts;
        public string name;

        public InputFileBigConstructor()
        {

        }

        public InputFileBigConstructor(long id, int parts, string name)
        {
            this.id = id;
            this.parts = parts;
            this.name = name;
        }


        public Constructor Constructor
        {
            get { return Constructor.inputFileBig; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xfa4f0bb5);
            writer.Write(this.id);
            writer.Write(this.parts);
            Serializers.String.write(writer, this.name);
        }

        public override void Read(BinaryReader reader)
        {
            this.id = reader.ReadInt64();
            this.parts = reader.ReadInt32();
            this.name = Serializers.String.read(reader);
        }

        public override string ToString()
        {
            return String.Format("(inputFileBig id:{0} parts:{1} name:'{2}')", id, parts, name);
        }
    }
}