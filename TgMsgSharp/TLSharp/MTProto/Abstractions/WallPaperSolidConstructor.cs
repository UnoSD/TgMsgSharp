using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class WallPaperSolidConstructor : WallPaper
    {
        public int id;
        public string title;
        public int bg_color;
        public int color;

        public WallPaperSolidConstructor()
        {

        }

        public WallPaperSolidConstructor(int id, string title, int bg_color, int color)
        {
            this.id = id;
            this.title = title;
            this.bg_color = bg_color;
            this.color = color;
        }


        public Constructor Constructor
        {
            get { return Constructor.wallPaperSolid; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x63117f24);
            writer.Write(this.id);
            Serializers.String.write(writer, this.title);
            writer.Write(this.bg_color);
            writer.Write(this.color);
        }

        public override void Read(BinaryReader reader)
        {
            this.id = reader.ReadInt32();
            this.title = Serializers.String.read(reader);
            this.bg_color = reader.ReadInt32();
            this.color = reader.ReadInt32();
        }

        public override string ToString()
        {
            return String.Format("(wallPaperSolid id:{0} title:'{1}' bg_color:{2} color:{3})", id, title, bg_color, color);
        }
    }
}