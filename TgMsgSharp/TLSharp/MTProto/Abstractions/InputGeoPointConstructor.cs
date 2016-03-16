using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class InputGeoPointConstructor : InputGeoPoint
    {
        public double lat;
        public double lng;

        public InputGeoPointConstructor()
        {

        }

        public InputGeoPointConstructor(double lat, double lng)
        {
            this.lat = lat;
            this.lng = lng;
        }


        public Constructor Constructor
        {
            get { return Constructor.inputGeoPoint; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xf3b7acc9);
            writer.Write(this.lat);
            writer.Write(this.lng);
        }

        public override void Read(BinaryReader reader)
        {
            this.lat = reader.ReadDouble();
            this.lng = reader.ReadDouble();
        }

        public override string ToString()
        {
            return String.Format("(inputGeoPoint lat:{0} long:{1})", lat, lng);
        }
    }
}