using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class PeerChatConstructor : Peer
    {
        public int chat_id;

        public PeerChatConstructor()
        {

        }

        public PeerChatConstructor(int chat_id)
        {
            this.chat_id = chat_id;
        }


        public Constructor Constructor
        {
            get { return Constructor.peerChat; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xbad0e5bb);
            writer.Write(this.chat_id);
        }

        public override void Read(BinaryReader reader)
        {
            this.chat_id = reader.ReadInt32();
        }

        public override string ToString()
        {
            return String.Format("(peerChat chat_id:{0})", chat_id);
        }
    }
}