using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class GeoChatMessageServiceConstructor : GeoChatMessage
    {
        public int chat_id;
        public int id;
        public int from_id;
        public int date;
        public MessageAction action;

        public GeoChatMessageServiceConstructor()
        {

        }

        public GeoChatMessageServiceConstructor(int chat_id, int id, int from_id, int date, MessageAction action)
        {
            this.chat_id = chat_id;
            this.id = id;
            this.from_id = from_id;
            this.date = date;
            this.action = action;
        }


        public Constructor Constructor
        {
            get { return Constructor.geoChatMessageService; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xd34fa24e);
            writer.Write(this.chat_id);
            writer.Write(this.id);
            writer.Write(this.from_id);
            writer.Write(this.date);
            this.action.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            this.chat_id = reader.ReadInt32();
            this.id = reader.ReadInt32();
            this.from_id = reader.ReadInt32();
            this.date = reader.ReadInt32();
            this.action = Tl.Parse<MessageAction>(reader);
        }

        public override string ToString()
        {
            return String.Format("(geoChatMessageService chat_id:{0} id:{1} from_id:{2} date:{3} action:{4})", chat_id, id,
                from_id, date, action);
        }
    }
}