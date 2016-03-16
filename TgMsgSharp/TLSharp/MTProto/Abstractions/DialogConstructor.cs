using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class DialogConstructor : Dialog
    {
        public Peer peer;
        public int top_message;
        public int unread_count;

        public DialogConstructor()
        {

        }

        public DialogConstructor(Peer peer, int top_message, int unread_count)
        {
            this.peer = peer;
            this.top_message = top_message;
            this.unread_count = unread_count;
        }


        public Constructor Constructor
        {
            get { return Constructor.dialog; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x214a8cdf);
            this.peer.Write(writer);
            writer.Write(this.top_message);
            writer.Write(this.unread_count);
        }

        public override void Read(BinaryReader reader)
        {
            this.peer = Tl.Parse<Peer>(reader);
            this.top_message = reader.ReadInt32();
            this.unread_count = reader.ReadInt32();
        }

        public override string ToString()
        {
            return String.Format("(dialog peer:{0} top_message:{1} unread_count:{2})", peer, top_message, unread_count);
        }
    }
}