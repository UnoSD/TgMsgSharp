using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class InputNotifyChatsConstructor : InputNotifyPeer
    {

        public InputNotifyChatsConstructor()
        {

        }



        public Constructor Constructor
        {
            get { return Constructor.inputNotifyChats; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x4a95e84e);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return String.Format("(inputNotifyChats)");
        }
    }
}