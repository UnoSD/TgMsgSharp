using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class InputPeerContactConstructor : InputPeer
    {
        public int user_id;

        public InputPeerContactConstructor()
        {

        }

        public InputPeerContactConstructor(int user_id)
        {
            this.user_id = user_id;
        }


        public Constructor Constructor
        {
            get { return Constructor.inputPeerContact; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x1023dbe8);
            writer.Write(this.user_id);
        }

        public override void Read(BinaryReader reader)
        {
            this.user_id = reader.ReadInt32();
        }

        public override string ToString()
        {
            return String.Format("(inputPeerContact user_id:{0})", user_id);
        }
    }
}