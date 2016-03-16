using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class Updates_differenceEmptyConstructor : updates_Difference
    {
        public int date;
        public int seq;

        public Updates_differenceEmptyConstructor()
        {

        }

        public Updates_differenceEmptyConstructor(int date, int seq)
        {
            this.date = date;
            this.seq = seq;
        }


        public Constructor Constructor
        {
            get { return Constructor.updates_differenceEmpty; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x5d75a138);
            writer.Write(this.date);
            writer.Write(this.seq);
        }

        public override void Read(BinaryReader reader)
        {
            this.date = reader.ReadInt32();
            this.seq = reader.ReadInt32();
        }

        public override string ToString()
        {
            return String.Format("(updates_differenceEmpty date:{0} seq:{1})", date, seq);
        }
    }
}