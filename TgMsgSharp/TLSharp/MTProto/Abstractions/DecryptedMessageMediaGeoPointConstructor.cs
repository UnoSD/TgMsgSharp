using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class DecryptedMessageMediaGeoPointConstructor : DecryptedMessageMedia
    {
        public double lat;
        public double lng;

        public DecryptedMessageMediaGeoPointConstructor()
        {

        }

        public DecryptedMessageMediaGeoPointConstructor(double lat, double lng)
        {
            this.lat = lat;
            this.lng = lng;
        }


        public Constructor Constructor
        {
            get { return Constructor.decryptedMessageMediaGeoPoint; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x35480a59);
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
            return String.Format("(decryptedMessageMediaGeoPoint lat:{0} long:{1})", lat, lng);
        }
    }
}