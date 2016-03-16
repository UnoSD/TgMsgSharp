using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class UpdateShortChatMessageConstructor : Updates
    {
        public int id;
        public int from_id;
        public int chat_id;
        public string message;
        public int pts;
        public int date;
        public int seq;

        public UpdateShortChatMessageConstructor()
        {

        }

        public UpdateShortChatMessageConstructor(int id, int from_id, int chat_id, string message, int pts, int date, int seq)
        {
            this.id = id;
            this.from_id = from_id;
            this.chat_id = chat_id;
            this.message = message;
            this.pts = pts;
            this.date = date;
            this.seq = seq;
        }


        public Constructor Constructor
        {
            get { return Constructor.updateShortChatMessage; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x2b2fbd4e);
            writer.Write(this.id);
            writer.Write(this.from_id);
            writer.Write(this.chat_id);
            Serializers.String.write(writer, this.message);
            writer.Write(this.pts);
            writer.Write(this.date);
            writer.Write(this.seq);
        }

        public override void Read(BinaryReader reader)
        {
            this.id = reader.ReadInt32();
            this.from_id = reader.ReadInt32();
            this.chat_id = reader.ReadInt32();
            this.message = Serializers.String.read(reader);
            this.pts = reader.ReadInt32();
            this.date = reader.ReadInt32();
            this.seq = reader.ReadInt32();
        }

        public override string ToString()
        {
            return String.Format(
                "(updateShortChatMessage id:{0} from_id:{1} chat_id:{2} message:'{3}' pts:{4} date:{5} seq:{6})", id, from_id,
                chat_id, message, pts, date, seq);
        }
    }
}