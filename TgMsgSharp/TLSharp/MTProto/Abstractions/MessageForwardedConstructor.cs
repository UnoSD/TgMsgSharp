using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class MessageForwardedConstructor : Message
    {
        public int id;
        public int fwd_from_id;
        public int fwd_date;
        public int from_id;
        public int to_id;
        public bool output;
        public bool unread;
        public int date;
        public string message;
        public MessageMedia media;

        public MessageForwardedConstructor()
        {

        }

        public MessageForwardedConstructor(int id, int fwd_from_id, int fwd_date, int from_id, int to_id, bool output,
            bool unread, int date, string message, MessageMedia media)
        {
            this.id = id;
            this.fwd_from_id = fwd_from_id;
            this.fwd_date = fwd_date;
            this.from_id = from_id;
            this.to_id = to_id;
            this.output = output;
            this.unread = unread;
            this.date = date;
            this.message = message;
            this.media = media;
        }


        public Constructor Constructor
        {
            get { return Constructor.messageForwarded; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x05f46804);
            writer.Write(this.id);
            writer.Write(this.fwd_from_id);
            writer.Write(this.fwd_date);
            writer.Write(this.from_id);
            writer.Write(this.to_id);
            writer.Write(this.output ? 0x997275b5 : 0xbc799737);
            writer.Write(this.unread ? 0x997275b5 : 0xbc799737);
            writer.Write(this.date);
            Serializers.String.write(writer, this.message);
            this.media.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            this.id = reader.ReadInt32();
            this.fwd_from_id = reader.ReadInt32();
            this.fwd_date = reader.ReadInt32();
            this.from_id = reader.ReadInt32();
            this.to_id = reader.ReadInt32();
            this.output = reader.ReadUInt32() == 0x997275b5;
            this.unread = reader.ReadUInt32() == 0x997275b5;
            this.date = reader.ReadInt32();
            this.message = Serializers.String.read(reader);
            this.media = Tl.Parse<MessageMedia>(reader);
        }

        public override string ToString()
        {
            return
                String.Format(
                    "(messageForwarded id:{0} fwd_from_id:{1} fwd_date:{2} from_id:{3} to_id:{4} out:{5} unread:{6} date:{7} message:'{8}' media:{9})",
                    id, fwd_from_id, fwd_date, from_id, to_id, output, unread, date, message, media);
        }
    }
}