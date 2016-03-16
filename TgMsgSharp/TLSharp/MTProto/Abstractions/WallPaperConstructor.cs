using System;
using System.Collections.Generic;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class WallPaperConstructor : WallPaper
    {
        public int id;
        public string title;
        public List<PhotoSize> sizes;
        public int color;

        public WallPaperConstructor()
        {

        }

        public WallPaperConstructor(int id, string title, List<PhotoSize> sizes, int color)
        {
            this.id = id;
            this.title = title;
            this.sizes = sizes;
            this.color = color;
        }


        public Constructor Constructor
        {
            get { return Constructor.wallPaper; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xccb03657);
            writer.Write(this.id);
            Serializers.String.write(writer, this.title);
            writer.Write(0x1cb5c415);
            writer.Write(this.sizes.Count);
            foreach (PhotoSize sizes_element in this.sizes)
            {
                sizes_element.Write(writer);
            }
            writer.Write(this.color);
        }

        public override void Read(BinaryReader reader)
        {
            this.id = reader.ReadInt32();
            this.title = Serializers.String.read(reader);
            reader.ReadInt32(); // vector code
            int sizes_len = reader.ReadInt32();
            this.sizes = new List<PhotoSize>(sizes_len);
            for (int sizes_index = 0; sizes_index < sizes_len; sizes_index++)
            {
                PhotoSize sizes_element;
                sizes_element = Tl.Parse<PhotoSize>(reader);
                this.sizes.Add(sizes_element);
            }
            this.color = reader.ReadInt32();
        }

        public override string ToString()
        {
            return String.Format("(wallPaper id:{0} title:'{1}' sizes:{2} color:{3})", id, title,
                Serializers.VectorToString(sizes), color);
        }
    }
}