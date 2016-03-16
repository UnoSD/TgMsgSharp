using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class GeoChatMessageConstructor : GeoChatMessage
    {
        public int chat_id;
        public int id;
        public int from_id;
        public int date;
        public string message;
        public MessageMedia media;

        public GeoChatMessageConstructor()
        {

        }

        public GeoChatMessageConstructor(int chat_id, int id, int from_id, int date, string message, MessageMedia media)
        {
            this.chat_id = chat_id;
            this.id = id;
            this.from_id = from_id;
            this.date = date;
            this.message = message;
            this.media = media;
        }


        public Constructor Constructor
        {
            get { return Constructor.geoChatMessage; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x4505f8e1);
            writer.Write(this.chat_id);
            writer.Write(this.id);
            writer.Write(this.from_id);
            writer.Write(this.date);
            Serializers.String.write(writer, this.message);
            this.media.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            this.chat_id = reader.ReadInt32();
            this.id = reader.ReadInt32();
            this.from_id = reader.ReadInt32();
            this.date = reader.ReadInt32();
            this.message = Serializers.String.read(reader);
            this.media = Tl.Parse<MessageMedia>(reader);
        }

        public override string ToString()
        {
            return String.Format("(geoChatMessage chat_id:{0} id:{1} from_id:{2} date:{3} message:'{4}' media:{5})", chat_id, id,
                from_id, date, message, media);
        }
    }
}