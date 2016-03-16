using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class InputMediaUploadedDocumentConstructor : InputMedia
    {
        public InputFile file;
        public string file_name;
        public string mime_type;

        public InputMediaUploadedDocumentConstructor()
        {

        }

        public InputMediaUploadedDocumentConstructor(InputFile file, string file_name, string mime_type)
        {
            this.file = file;
            this.file_name = file_name;
            this.mime_type = mime_type;
        }


        public Constructor Constructor
        {
            get { return Constructor.inputMediaUploadedDocument; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x34e794bd);
            this.file.Write(writer);
            Serializers.String.write(writer, this.file_name);
            Serializers.String.write(writer, this.mime_type);
        }

        public override void Read(BinaryReader reader)
        {
            this.file = Tl.Parse<InputFile>(reader);
            this.file_name = Serializers.String.read(reader);
            this.mime_type = Serializers.String.read(reader);
        }

        public override string ToString()
        {
            return String.Format("(inputMediaUploadedDocument file:{0} file_name:'{1}' mime_type:'{2}')", file, file_name,
                mime_type);
        }
    }
}