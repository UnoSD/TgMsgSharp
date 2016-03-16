using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class DocumentEmptyConstructor : Document
    {
        public long id;

        public DocumentEmptyConstructor()
        {

        }

        public DocumentEmptyConstructor(long id)
        {
            this.id = id;
        }


        public Constructor Constructor
        {
            get { return Constructor.documentEmpty; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x36f8c871);
            writer.Write(this.id);
        }

        public override void Read(BinaryReader reader)
        {
            this.id = reader.ReadInt64();
        }

        public override string ToString()
        {
            return String.Format("(documentEmpty id:{0})", id);
        }
    }
}