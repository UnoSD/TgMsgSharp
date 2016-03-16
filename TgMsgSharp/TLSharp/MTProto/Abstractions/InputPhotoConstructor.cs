using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class InputPhotoConstructor : InputPhoto
    {
        public long id;
        public long access_hash;

        public InputPhotoConstructor()
        {

        }

        public InputPhotoConstructor(long id, long access_hash)
        {
            this.id = id;
            this.access_hash = access_hash;
        }


        public Constructor Constructor
        {
            get { return Constructor.inputPhoto; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xfb95c6c4);
            writer.Write(this.id);
            writer.Write(this.access_hash);
        }

        public override void Read(BinaryReader reader)
        {
            this.id = reader.ReadInt64();
            this.access_hash = reader.ReadInt64();
        }

        public override string ToString()
        {
            return String.Format("(inputPhoto id:{0} access_hash:{1})", id, access_hash);
        }
    }
}