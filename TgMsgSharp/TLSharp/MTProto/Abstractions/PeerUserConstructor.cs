using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class PeerUserConstructor : Peer
    {
        public int user_id;

        public PeerUserConstructor()
        {

        }

        public PeerUserConstructor(int user_id)
        {
            this.user_id = user_id;
        }


        public Constructor Constructor
        {
            get { return Constructor.peerUser; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x9db1bc6d);
            writer.Write(this.user_id);
        }

        public override void Read(BinaryReader reader)
        {
            this.user_id = reader.ReadInt32();
        }

        public override string ToString()
        {
            return String.Format("(peerUser user_id:{0})", user_id);
        }
    }
}