using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class VideoConstructor : Video
    {
        public long id;
        public long access_hash;
        public int user_id;
        public int date;
        public string caption;
        public int duration;
        public int size;
        public PhotoSize thumb;
        public int dc_id;
        public int w;
        public int h;
        string mime_type;

        public VideoConstructor()
        {

        }

        public VideoConstructor(long id, long access_hash, int user_id, int date, string caption, int duration, int size,
            PhotoSize thumb, int dc_id, int w, int h)
        {
            this.id = id;
            this.access_hash = access_hash;
            this.user_id = user_id;
            this.date = date;
            this.caption = caption;
            this.duration = duration;
            this.size = size;
            this.thumb = thumb;
            this.dc_id = dc_id;
            this.w = w;
            this.h = h;
        }


        public Constructor Constructor
        {
            get { return Constructor.video; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x5a04a49f);
            writer.Write(this.id);
            writer.Write(this.access_hash);
            writer.Write(this.user_id);
            writer.Write(this.date);
            Serializers.String.write(writer, this.caption);
            writer.Write(this.duration);
            writer.Write(this.size);
            this.thumb.Write(writer);
            writer.Write(this.dc_id);
            writer.Write(this.w);
            writer.Write(this.h);
        }

        public override void Read(BinaryReader reader)
        {
            //video#388fa391 id:long access_hash:long user_id:int date:int caption:string duration:int mime_type:string size:int thumb:PhotoSize dc_id:int w:int h:int = Video;

            this.id = reader.ReadInt64();
            this.access_hash = reader.ReadInt64();
            this.user_id = reader.ReadInt32();
            this.date = reader.ReadInt32();
            this.caption = Serializers.String.read(reader);
            this.duration = reader.ReadInt32();
            this.mime_type = Serializers.String.read(reader);
            this.size = reader.ReadInt32();
            this.thumb = Tl.Parse<PhotoSize>(reader);
            this.dc_id = reader.ReadInt32();
            this.w = reader.ReadInt32();
            this.h = reader.ReadInt32();
        }

        public override string ToString()
        {
            return
                String.Format(
                    "(video id:{0} access_hash:{1} user_id:{2} date:{3} caption:'{4}' duration:{5} size:{6} thumb:{7} dc_id:{8} w:{9} h:{10})",
                    id, access_hash, user_id, date, caption, duration, size, thumb, dc_id, w, h);
        }
    }
}