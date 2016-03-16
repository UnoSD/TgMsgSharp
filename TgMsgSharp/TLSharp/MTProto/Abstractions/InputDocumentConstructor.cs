using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class InputDocumentConstructor : InputDocument
    {
        public long id;
        public long access_hash;

        public InputDocumentConstructor()
        {

        }

        public InputDocumentConstructor(long id, long access_hash)
        {
            this.id = id;
            this.access_hash = access_hash;
        }


        public Constructor Constructor
        {
            get { return Constructor.inputDocument; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x18798952);
            writer.Write(this.id);
            writer.Write(this.access_hash);
        }

        public override void Read(BinaryReader reader)
        {
            this.id = reader.ReadInt64();
            this.access_hash = reader.ReadInt64();
        }

        public override string ToString()
        {
            return String.Format("(inputDocument id:{0} access_hash:{1})", id, access_hash);
        }
    }
}