using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class Messages_affectedHistoryConstructor : messages_AffectedHistory
    {
        public int pts;
        public int seq;
        public int offset;

        public Messages_affectedHistoryConstructor()
        {

        }

        public Messages_affectedHistoryConstructor(int pts, int seq, int offset)
        {
            this.pts = pts;
            this.seq = seq;
            this.offset = offset;
        }


        public Constructor Constructor
        {
            get { return Constructor.messages_affectedHistory; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xb7de36f2);
            writer.Write(this.pts);
            writer.Write(this.seq);
            writer.Write(this.offset);
        }

        public override void Read(BinaryReader reader)
        {
            this.pts = reader.ReadInt32();
            this.seq = reader.ReadInt32();
            this.offset = reader.ReadInt32();
        }

        public override string ToString()
        {
            return String.Format("(messages_affectedHistory pts:{0} seq:{1} offset:{2})", pts, seq, offset);
        }
    }
}