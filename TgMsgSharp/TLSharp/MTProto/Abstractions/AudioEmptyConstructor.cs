using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class AudioEmptyConstructor : Audio
    {
        public long id;

        public AudioEmptyConstructor()
        {

        }

        public AudioEmptyConstructor(long id)
        {
            this.id = id;
        }


        public Constructor Constructor
        {
            get { return Constructor.audioEmpty; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x586988d8);
            writer.Write(this.id);
        }

        public override void Read(BinaryReader reader)
        {
            this.id = reader.ReadInt64();
        }

        public override string ToString()
        {
            return String.Format("(audioEmpty id:{0})", id);
        }
    }
}