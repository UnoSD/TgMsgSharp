using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class ChatConstructor : Chat
    {
        public int id;
        public string title;
        public ChatPhoto photo;
        public int participants_count;
        public int date;
        public bool left;
        public int version;

        public ChatConstructor()
        {

        }

        public ChatConstructor(int id, string title, ChatPhoto photo, int participants_count, int date, bool left, int version)
        {
            this.id = id;
            this.title = title;
            this.photo = photo;
            this.participants_count = participants_count;
            this.date = date;
            this.left = left;
            this.version = version;
        }


        public Constructor Constructor
        {
            get { return Constructor.chat; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x6e9c9bc7);
            writer.Write(this.id);
            Serializers.String.write(writer, this.title);
            this.photo.Write(writer);
            writer.Write(this.participants_count);
            writer.Write(this.date);
            writer.Write(this.left ? 0x997275b5 : 0xbc799737);
            writer.Write(this.version);
        }

        public override void Read(BinaryReader reader)
        {
            this.id = reader.ReadInt32();
            this.title = Serializers.String.read(reader);
            this.photo = Tl.Parse<ChatPhoto>(reader);
            this.participants_count = reader.ReadInt32();
            this.date = reader.ReadInt32();
            this.left = reader.ReadUInt32() == 0x997275b5;
            this.version = reader.ReadInt32();
        }

        public override string ToString()
        {
            return String.Format("(chat id:{0} title:'{1}' photo:{2} participants_count:{3} date:{4} left:{5} version:{6})", id,
                title, photo, participants_count, date, left, version);
        }
    }
}