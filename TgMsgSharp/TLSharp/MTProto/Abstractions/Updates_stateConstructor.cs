using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class Updates_stateConstructor : updates_State
    {
        public int pts;
        public int qts;
        public int date;
        public int seq;
        public int unread_count;

        public Updates_stateConstructor()
        {

        }

        public Updates_stateConstructor(int pts, int qts, int date, int seq, int unread_count)
        {
            this.pts = pts;
            this.qts = qts;
            this.date = date;
            this.seq = seq;
            this.unread_count = unread_count;
        }


        public Constructor Constructor
        {
            get { return Constructor.updates_state; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xa56c2a3e);
            writer.Write(this.pts);
            writer.Write(this.qts);
            writer.Write(this.date);
            writer.Write(this.seq);
            writer.Write(this.unread_count);
        }

        public override void Read(BinaryReader reader)
        {
            this.pts = reader.ReadInt32();
            this.qts = reader.ReadInt32();
            this.date = reader.ReadInt32();
            this.seq = reader.ReadInt32();
            this.unread_count = reader.ReadInt32();
        }

        public override string ToString()
        {
            return String.Format("(updates_state pts:{0} qts:{1} date:{2} seq:{3} unread_count:{4})", pts, qts, date, seq,
                unread_count);
        }
    }
}