using System;
using System.Collections.Generic;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class PhotoConstructor : Photo
    {
        public long id;
        public long access_hash;
        public int user_id;
        public int date;
        public string caption;
        public GeoPoint geo;
        public List<PhotoSize> sizes;

        public PhotoConstructor()
        {

        }

        public PhotoConstructor(long id, long access_hash, int user_id, int date, string caption, GeoPoint geo,
            List<PhotoSize> sizes)
        {
            this.id = id;
            this.access_hash = access_hash;
            this.user_id = user_id;
            this.date = date;
            this.caption = caption;
            this.geo = geo;
            this.sizes = sizes;
        }


        public Constructor Constructor
        {
            get { return Constructor.photo; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x22b56751);
            writer.Write(this.id);
            writer.Write(this.access_hash);
            writer.Write(this.user_id);
            writer.Write(this.date);
            Serializers.String.write(writer, this.caption);
            this.geo.Write(writer);
            writer.Write(0x1cb5c415);
            writer.Write(this.sizes.Count);
            foreach (PhotoSize sizes_element in this.sizes)
            {
                sizes_element.Write(writer);
            }
        }

        public override void Read(BinaryReader reader)
        {
            this.id = reader.ReadInt64();
            this.access_hash = reader.ReadInt64();
            this.user_id = reader.ReadInt32();
            this.date = reader.ReadInt32();
            this.caption = Serializers.String.read(reader);
            this.geo = Tl.Parse<GeoPoint>(reader);
            reader.ReadInt32(); // vector code
            int sizes_len = reader.ReadInt32();
            this.sizes = new List<PhotoSize>(sizes_len);
            for (int sizes_index = 0; sizes_index < sizes_len; sizes_index++)
            {
                PhotoSize sizes_element;
                sizes_element = Tl.Parse<PhotoSize>(reader);
                this.sizes.Add(sizes_element);
            }
        }

        public override string ToString()
        {
            return String.Format("(photo id:{0} access_hash:{1} user_id:{2} date:{3} caption:'{4}' geo:{5} sizes:{6})", id,
                access_hash, user_id, date, caption, geo, Serializers.VectorToString(sizes));
        }
    }
}