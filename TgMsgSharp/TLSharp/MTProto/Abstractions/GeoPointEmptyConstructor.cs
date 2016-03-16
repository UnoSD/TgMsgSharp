using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class GeoPointEmptyConstructor : GeoPoint
    {

        public GeoPointEmptyConstructor()
        {

        }



        public Constructor Constructor
        {
            get { return Constructor.geoPointEmpty; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x1117dd5f);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return String.Format("(geoPointEmpty)");
        }
    }
}