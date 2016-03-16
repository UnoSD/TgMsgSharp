using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class UpdateShortMessageConstructor : Updates
    {
        public int id;
        public int from_id;
        public string message;
        public int pts;
        public int date;
        public int seq;

        public UpdateShortMessageConstructor()
        {

        }

        public UpdateShortMessageConstructor(int id, int from_id, string message, int pts, int date, int seq)
        {
            this.id = id;
            this.from_id = from_id;
            this.message = message;
            this.pts = pts;
            this.date = date;
            this.seq = seq;
        }


        public Constructor Constructor
        {
            get { return Constructor.updateShortMessage; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xd3f45784);
            writer.Write(this.id);
            writer.Write(this.from_id);
            Serializers.String.write(writer, this.message);
            writer.Write(this.pts);
            writer.Write(this.date);
            writer.Write(this.seq);
        }

        public override void Read(BinaryReader reader)
        {
            this.id = reader.ReadInt32();
            this.from_id = reader.ReadInt32();
            this.message = Serializers.String.read(reader);
            this.pts = reader.ReadInt32();
            this.date = reader.ReadInt32();
            this.seq = reader.ReadInt32();
        }

        public override string ToString()
        {
            return String.Format("(updateShortMessage id:{0} from_id:{1} message:'{2}' pts:{3} date:{4} seq:{5})", id, from_id,
                message, pts, date, seq);
        }
    }
}