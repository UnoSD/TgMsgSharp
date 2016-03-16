using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class PhotoSizeConstructor : PhotoSize
    {
        public string type;
        public FileLocation location;
        public int w;
        public int h;
        public int size;

        public PhotoSizeConstructor()
        {

        }

        public PhotoSizeConstructor(string type, FileLocation location, int w, int h, int size)
        {
            this.type = type;
            this.location = location;
            this.w = w;
            this.h = h;
            this.size = size;
        }


        public Constructor Constructor
        {
            get { return Constructor.photoSize; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x77bfb61b);
            Serializers.String.write(writer, this.type);
            this.location.Write(writer);
            writer.Write(this.w);
            writer.Write(this.h);
            writer.Write(this.size);
        }

        public override void Read(BinaryReader reader)
        {
            this.type = Serializers.String.read(reader);
            this.location = Tl.Parse<FileLocation>(reader);
            this.w = reader.ReadInt32();
            this.h = reader.ReadInt32();
            this.size = reader.ReadInt32();
        }

        public override string ToString()
        {
            return String.Format("(photoSize type:'{0}' location:{1} w:{2} h:{3} size:{4})", type, location, w, h, size);
        }
    }
}