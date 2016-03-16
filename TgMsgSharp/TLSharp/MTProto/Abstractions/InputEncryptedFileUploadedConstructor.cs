using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class InputEncryptedFileUploadedConstructor : InputEncryptedFile
    {
        public long id;
        public int parts;
        public string md5_checksum;
        public int key_fingerprint;

        public InputEncryptedFileUploadedConstructor()
        {

        }

        public InputEncryptedFileUploadedConstructor(long id, int parts, string md5_checksum, int key_fingerprint)
        {
            this.id = id;
            this.parts = parts;
            this.md5_checksum = md5_checksum;
            this.key_fingerprint = key_fingerprint;
        }


        public Constructor Constructor
        {
            get { return Constructor.inputEncryptedFileUploaded; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x64bd0306);
            writer.Write(this.id);
            writer.Write(this.parts);
            Serializers.String.write(writer, this.md5_checksum);
            writer.Write(this.key_fingerprint);
        }

        public override void Read(BinaryReader reader)
        {
            this.id = reader.ReadInt64();
            this.parts = reader.ReadInt32();
            this.md5_checksum = Serializers.String.read(reader);
            this.key_fingerprint = reader.ReadInt32();
        }

        public override string ToString()
        {
            return String.Format("(inputEncryptedFileUploaded id:{0} parts:{1} md5_checksum:'{2}' key_fingerprint:{3})", id,
                parts, md5_checksum, key_fingerprint);
        }
    }
}