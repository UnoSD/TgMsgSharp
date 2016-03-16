using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class Help_noAppUpdateConstructor : help_AppUpdate
    {

        public Help_noAppUpdateConstructor()
        {

        }



        public Constructor Constructor
        {
            get { return Constructor.help_noAppUpdate; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xc45a6536);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return String.Format("(help_noAppUpdate)");
        }
    }
}