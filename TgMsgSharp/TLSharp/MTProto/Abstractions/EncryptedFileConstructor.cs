using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class EncryptedFileConstructor : EncryptedFile
    {
        public long id;
        public long access_hash;
        public int size;
        public int dc_id;
        public int key_fingerprint;

        public EncryptedFileConstructor()
        {

        }

        public EncryptedFileConstructor(long id, long access_hash, int size, int dc_id, int key_fingerprint)
        {
            this.id = id;
            this.access_hash = access_hash;
            this.size = size;
            this.dc_id = dc_id;
            this.key_fingerprint = key_fingerprint;
        }


        public Constructor Constructor
        {
            get { return Constructor.encryptedFile; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x4a70994c);
            writer.Write(this.id);
            writer.Write(this.access_hash);
            writer.Write(this.size);
            writer.Write(this.dc_id);
            writer.Write(this.key_fingerprint);
        }

        public override void Read(BinaryReader reader)
        {
            this.id = reader.ReadInt64();
            this.access_hash = reader.ReadInt64();
            this.size = reader.ReadInt32();
            this.dc_id = reader.ReadInt32();
            this.key_fingerprint = reader.ReadInt32();
        }

        public override string ToString()
        {
            return String.Format("(encryptedFile id:{0} access_hash:{1} size:{2} dc_id:{3} key_fingerprint:{4})", id, access_hash,
                size, dc_id, key_fingerprint);
        }
    }
}