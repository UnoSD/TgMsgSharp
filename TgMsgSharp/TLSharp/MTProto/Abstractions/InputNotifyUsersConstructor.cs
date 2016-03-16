using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class InputNotifyUsersConstructor : InputNotifyPeer
    {

        public InputNotifyUsersConstructor()
        {

        }



        public Constructor Constructor
        {
            get { return Constructor.inputNotifyUsers; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x193b4417);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return String.Format("(inputNotifyUsers)");
        }
    }
}