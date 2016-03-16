using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class ChatForbiddenConstructor : Chat
    {
        public int id;
        public string title;
        public int date;

        public ChatForbiddenConstructor()
        {

        }

        public ChatForbiddenConstructor(int id, string title, int date)
        {
            this.id = id;
            this.title = title;
            this.date = date;
        }


        public Constructor Constructor
        {
            get { return Constructor.chatForbidden; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xfb0ccc41);
            writer.Write(this.id);
            Serializers.String.write(writer, this.title);
            writer.Write(this.date);
        }

        public override void Read(BinaryReader reader)
        {
            this.id = reader.ReadInt32();
            this.title = Serializers.String.read(reader);
            this.date = reader.ReadInt32();
        }

        public override string ToString()
        {
            return String.Format("(chatForbidden id:{0} title:'{1}' date:{2})", id, title, date);
        }
    }
}