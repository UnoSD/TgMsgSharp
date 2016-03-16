using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class InputUserSelfConstructor : InputUser
    {

        public InputUserSelfConstructor()
        {

        }



        public Constructor Constructor
        {
            get { return Constructor.inputUserSelf; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xf7c1b13f);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return String.Format("(inputUserSelf)");
        }
    }
}