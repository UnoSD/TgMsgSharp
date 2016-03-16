using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class Messages_sentMessageConstructor : messages_SentMessage
    {
        public int id;
        public int date;
        public int pts;
        public int seq;

        public Messages_sentMessageConstructor()
        {

        }

        public Messages_sentMessageConstructor(int id, int date, int pts, int seq)
        {
            this.id = id;
            this.date = date;
            this.pts = pts;
            this.seq = seq;
        }


        public Constructor Constructor
        {
            get { return Constructor.messages_sentMessage; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xd1f4d35c);
            writer.Write(this.id);
            writer.Write(this.date);
            writer.Write(this.pts);
            writer.Write(this.seq);
        }

        public override void Read(BinaryReader reader)
        {
            this.id = reader.ReadInt32();
            this.date = reader.ReadInt32();
            this.pts = reader.ReadInt32();
            this.seq = reader.ReadInt32();
        }

        public override string ToString()
        {
            return String.Format("(messages_sentMessage id:{0} date:{1} pts:{2} seq:{3})", id, date, pts, seq);
        }
    }
}