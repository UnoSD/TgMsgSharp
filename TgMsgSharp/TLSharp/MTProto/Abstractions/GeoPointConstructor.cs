using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class GeoPointConstructor : GeoPoint
    {
        public double lng;
        public double lat;

        public GeoPointConstructor()
        {

        }

        public GeoPointConstructor(double lng, double lat)
        {
            this.lng = lng;
            this.lat = lat;
        }


        public Constructor Constructor
        {
            get { return Constructor.geoPoint; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x2049d70c);
            writer.Write(this.lng);
            writer.Write(this.lat);
        }

        public override void Read(BinaryReader reader)
        {
            this.lng = reader.ReadDouble();
            this.lat = reader.ReadDouble();
        }

        public override string ToString()
        {
            return String.Format("(geoPoint long:{0} lat:{1})", lng, lat);
        }
    }
}