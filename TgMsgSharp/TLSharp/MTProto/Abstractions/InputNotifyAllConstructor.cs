using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class InputNotifyAllConstructor : InputNotifyPeer
    {

        public InputNotifyAllConstructor()
        {

        }



        public Constructor Constructor
        {
            get { return Constructor.inputNotifyAll; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xa429b886);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return String.Format("(inputNotifyAll)");
        }
    }
}