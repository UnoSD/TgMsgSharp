using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class InputPeerChatConstructor : InputPeer
    {
        public int chat_id;

        public InputPeerChatConstructor()
        {

        }

        public InputPeerChatConstructor(int chat_id)
        {
            this.chat_id = chat_id;
        }


        public Constructor Constructor
        {
            get { return Constructor.inputPeerChat; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x179be863);
            writer.Write(this.chat_id);
        }

        public override void Read(BinaryReader reader)
        {
            this.chat_id = reader.ReadInt32();
        }

        public override string ToString()
        {
            return String.Format("(inputPeerChat chat_id:{0})", chat_id);
        }
    }
}