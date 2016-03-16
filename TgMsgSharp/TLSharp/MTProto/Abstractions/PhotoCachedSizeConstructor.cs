using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class PhotoCachedSizeConstructor : PhotoSize
    {
        public string type;
        public FileLocation location;
        public int w;
        public int h;
        public byte[] bytes;

        public PhotoCachedSizeConstructor()
        {

        }

        public PhotoCachedSizeConstructor(string type, FileLocation location, int w, int h, byte[] bytes)
        {
            this.type = type;
            this.location = location;
            this.w = w;
            this.h = h;
            this.bytes = bytes;
        }


        public Constructor Constructor
        {
            get { return Constructor.photoCachedSize; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xe9a734fa);
            Serializers.String.write(writer, this.type);
            this.location.Write(writer);
            writer.Write(this.w);
            writer.Write(this.h);
            Serializers.Bytes.write(writer, this.bytes);
        }

        public override void Read(BinaryReader reader)
        {
            this.type = Serializers.String.read(reader);
            this.location = Tl.Parse<FileLocation>(reader);
            this.w = reader.ReadInt32();
            this.h = reader.ReadInt32();
            this.bytes = Serializers.Bytes.read(reader);
        }

        public override string ToString()
        {
            return String.Format("(photoCachedSize type:'{0}' location:{1} w:{2} h:{3} bytes:{4})", type, location, w, h,
                BitConverter.ToString(bytes));
        }
    }
}