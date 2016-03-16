using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class PhotoSizeEmptyConstructor : PhotoSize
    {
        public string type;

        public PhotoSizeEmptyConstructor()
        {

        }

        public PhotoSizeEmptyConstructor(string type)
        {
            this.type = type;
        }


        public Constructor Constructor
        {
            get { return Constructor.photoSizeEmpty; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x0e17e23c);
            Serializers.String.write(writer, this.type);
        }

        public override void Read(BinaryReader reader)
        {
            this.type = Serializers.String.read(reader);
        }

        public override string ToString()
        {
            return String.Format("(photoSizeEmpty type:'{0}')", type);
        }
    }
}