using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class InputGeoPointEmptyConstructor : InputGeoPoint
    {

        public InputGeoPointEmptyConstructor()
        {

        }



        public Constructor Constructor
        {
            get { return Constructor.inputGeoPointEmpty; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xe4c123d6);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return String.Format("(inputGeoPointEmpty)");
        }
    }
}