using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class ErrorConstructor : Error
    {
        public int code;
        public string text;

        public ErrorConstructor()
        {

        }

        public ErrorConstructor(int code, string text)
        {
            this.code = code;
            this.text = text;
        }


        public Constructor Constructor
        {
            get { return Constructor.error; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xc4b9f9bb);
            writer.Write(this.code);
            Serializers.String.write(writer, this.text);
        }

        public override void Read(BinaryReader reader)
        {
            this.code = reader.ReadInt32();
            this.text = Serializers.String.read(reader);
        }

        public override string ToString()
        {
            return String.Format("(error code:{0} text:'{1}')", code, text);
        }
    }
}