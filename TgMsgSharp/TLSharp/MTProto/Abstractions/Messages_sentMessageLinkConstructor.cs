using System;
using System.Collections.Generic;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class Messages_sentMessageLinkConstructor : messages_SentMessage
    {
        public int id;
        public int date;
        public int pts;
        public int seq;
        public List<contacts_Link> links;

        public Messages_sentMessageLinkConstructor()
        {

        }

        public Messages_sentMessageLinkConstructor(int id, int date, int pts, int seq, List<contacts_Link> links)
        {
            this.id = id;
            this.date = date;
            this.pts = pts;
            this.seq = seq;
            this.links = links;
        }


        public Constructor Constructor
        {
            get { return Constructor.messages_sentMessageLink; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xe9db4a3f);
            writer.Write(this.id);
            writer.Write(this.date);
            writer.Write(this.pts);
            writer.Write(this.seq);
            writer.Write(0x1cb5c415);
            writer.Write(this.links.Count);
            foreach (contacts_Link links_element in this.links)
            {
                links_element.Write(writer);
            }
        }

        public override void Read(BinaryReader reader)
        {
            this.id = reader.ReadInt32();
            this.date = reader.ReadInt32();
            this.pts = reader.ReadInt32();
            this.seq = reader.ReadInt32();
            reader.ReadInt32(); // vector code
            int links_len = reader.ReadInt32();
            this.links = new List<contacts_Link>(links_len);
            for (int links_index = 0; links_index < links_len; links_index++)
            {
                contacts_Link links_element;
                links_element = Tl.Parse<contacts_Link>(reader);
                this.links.Add(links_element);
            }
        }

        public override string ToString()
        {
            return String.Format("(messages_sentMessageLink id:{0} date:{1} pts:{2} seq:{3} links:{4})", id, date, pts, seq,
                Serializers.VectorToString(links));
        }
    }
}