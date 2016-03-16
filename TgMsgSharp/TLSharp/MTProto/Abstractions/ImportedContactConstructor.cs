using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class ImportedContactConstructor : ImportedContact
    {
        public int user_id;
        public long client_id;

        public ImportedContactConstructor()
        {

        }

        public ImportedContactConstructor(int user_id, long client_id)
        {
            this.user_id = user_id;
            this.client_id = client_id;
        }


        public Constructor Constructor
        {
            get { return Constructor.importedContact; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xd0028438);
            writer.Write(this.user_id);
            writer.Write(this.client_id);
        }

        public override void Read(BinaryReader reader)
        {
            this.user_id = reader.ReadInt32();
            this.client_id = reader.ReadInt64();
        }

        public override string ToString()
        {
            return String.Format("(importedContact user_id:{0} client_id:{1})", user_id, client_id);
        }
    }
}