using System;
using System.Collections.Generic;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class DocumentConstructor : Document
    {
        public long id;
        public long access_hash;
        public int user_id;
        public int date;
        public string file_name;
        public string mime_type;
        public int size;
        public PhotoSize thumb;
        public int dc_id;

        public DocumentConstructor()
        {

        }

        public DocumentConstructor(long id, long access_hash, int user_id, int date, string file_name, string mime_type,
            int size, PhotoSize thumb, int dc_id)
        {
            this.id = id;
            this.access_hash = access_hash;
            this.user_id = user_id;
            this.date = date;
            this.file_name = file_name;
            this.mime_type = mime_type;
            this.size = size;
            this.thumb = thumb;
            this.dc_id = dc_id;
        }


        public Constructor Constructor
        {
            get { return Constructor.document; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x9efc6326);
            writer.Write(this.id);
            writer.Write(this.access_hash);
            writer.Write(this.user_id);
            writer.Write(this.date);
            Serializers.String.write(writer, this.file_name);
            Serializers.String.write(writer, this.mime_type);
            writer.Write(this.size);
            this.thumb.Write(writer);
            writer.Write(this.dc_id);
        }

        public override void Read(BinaryReader reader)
        {
            //document#f9a39f4f id:long access_hash:long date:int mime_type:string size:int thumb:PhotoSize dc_id:int attributes:Vector<DocumentAttribute> = Document;

            this.id = reader.ReadInt64();
            this.access_hash = reader.ReadInt64();
            this.date = reader.ReadInt32();
            this.mime_type = Serializers.String.read(reader);
            this.size = reader.ReadInt32();
            this.thumb = TL.Parse<PhotoSize>(reader);
            this.dc_id = reader.ReadInt32();

            // Vector
            var vectorCode = reader.ReadInt32();
            var vectorSize = reader.ReadInt32();

            var documentAttributes = new List<DocumentAttribute>();

            for (var index = 0; index < vectorSize; index++)
            {
                var attribute = TL.Parse<DocumentAttribute>(reader);

                documentAttributes.Add(attribute);
            }
        }

        public override string ToString()
        {
            return
                String.Format(
                    "(document id:{0} access_hash:{1} user_id:{2} date:{3} file_name:'{4}' mime_type:'{5}' size:{6} thumb:{7} dc_id:{8})",
                    id, access_hash, user_id, date, file_name, mime_type, size, thumb, dc_id);
        }
    }
}