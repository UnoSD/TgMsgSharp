using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class InputMediaUploadedThumbDocumentConstructor : InputMedia
    {
        public InputFile file;
        public InputFile thumb;
        public string file_name;
        public string mime_type;

        public InputMediaUploadedThumbDocumentConstructor()
        {

        }

        public InputMediaUploadedThumbDocumentConstructor(InputFile file, InputFile thumb, string file_name, string mime_type)
        {
            this.file = file;
            this.thumb = thumb;
            this.file_name = file_name;
            this.mime_type = mime_type;
        }


        public Constructor Constructor
        {
            get { return Constructor.inputMediaUploadedThumbDocument; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x3e46de5d);
            this.file.Write(writer);
            this.thumb.Write(writer);
            Serializers.String.write(writer, this.file_name);
            Serializers.String.write(writer, this.mime_type);
        }

        public override void Read(BinaryReader reader)
        {
            this.file = Tl.Parse<InputFile>(reader);
            this.thumb = Tl.Parse<InputFile>(reader);
            this.file_name = Serializers.String.read(reader);
            this.mime_type = Serializers.String.read(reader);
        }

        public override string ToString()
        {
            return String.Format("(inputMediaUploadedThumbDocument file:{0} thumb:{1} file_name:'{2}' mime_type:'{3}')", file,
                thumb, file_name, mime_type);
        }
    }
}