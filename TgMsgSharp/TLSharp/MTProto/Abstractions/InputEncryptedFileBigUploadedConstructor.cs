using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class InputEncryptedFileBigUploadedConstructor : InputEncryptedFile
    {
        public long id;
        public int parts;
        public int key_fingerprint;

        public InputEncryptedFileBigUploadedConstructor()
        {

        }

        public InputEncryptedFileBigUploadedConstructor(long id, int parts, int key_fingerprint)
        {
            this.id = id;
            this.parts = parts;
            this.key_fingerprint = key_fingerprint;
        }


        public Constructor Constructor
        {
            get { return Constructor.inputEncryptedFileBigUploaded; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x2dc173c8);
            writer.Write(this.id);
            writer.Write(this.parts);
            writer.Write(this.key_fingerprint);
        }

        public override void Read(BinaryReader reader)
        {
            this.id = reader.ReadInt64();
            this.parts = reader.ReadInt32();
            this.key_fingerprint = reader.ReadInt32();
        }

        public override string ToString()
        {
            return String.Format("(inputEncryptedFileBigUploaded id:{0} parts:{1} key_fingerprint:{2})", id, parts,
                key_fingerprint);
        }
    }
}