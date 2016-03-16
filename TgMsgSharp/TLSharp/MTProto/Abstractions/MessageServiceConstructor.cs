using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class MessageServiceConstructor : Message
    {
        public int id;
        public int from_id;
        public Peer to_id;
        public bool output;
        public bool unread;
        public int date;
        public MessageAction action;

        public MessageServiceConstructor()
        {

        }

        public MessageServiceConstructor(int id, int from_id, Peer to_id, bool output, bool unread, int date,
            MessageAction action)
        {
            this.id = id;
            this.from_id = from_id;
            this.to_id = to_id;
            this.output = output;
            this.unread = unread;
            this.date = date;
            this.action = action;
        }


        public Constructor Constructor
        {
            get { return Constructor.messageService; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x9f8d60bb);
            writer.Write(this.id);
            writer.Write(this.from_id);
            this.to_id.Write(writer);
            writer.Write(this.output ? 0x997275b5 : 0xbc799737);
            writer.Write(this.unread ? 0x997275b5 : 0xbc799737);
            writer.Write(this.date);
            this.action.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            this.id = reader.ReadInt32();
            this.from_id = reader.ReadInt32();
            this.to_id = Tl.Parse<Peer>(reader);
            this.output = reader.ReadUInt32() == 0x997275b5;
            this.unread = reader.ReadUInt32() == 0x997275b5;
            this.date = reader.ReadInt32();
            this.action = Tl.Parse<MessageAction>(reader);
        }

        public override string ToString()
        {
            return String.Format("(messageService id:{0} from_id:{1} to_id:{2} out:{3} unread:{4} date:{5} action:{6})", id,
                from_id, to_id, output, unread, date, action);
        }
    }
}