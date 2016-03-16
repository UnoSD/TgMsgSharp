using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class PhotoEmptyConstructor : Photo
    {
        public long id;

        public PhotoEmptyConstructor()
        {

        }

        public PhotoEmptyConstructor(long id)
        {
            this.id = id;
        }


        public Constructor Constructor
        {
            get { return Constructor.photoEmpty; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x2331b22d);
            writer.Write(this.id);
        }

        public override void Read(BinaryReader reader)
        {
            this.id = reader.ReadInt64();
        }

        public override string ToString()
        {
            return String.Format("(photoEmpty id:{0})", id);
        }
    }
}