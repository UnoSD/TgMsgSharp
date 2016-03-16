using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class MessageMediaGeoConstructor : MessageMedia
    {
        public GeoPoint geo;

        public MessageMediaGeoConstructor()
        {

        }

        public MessageMediaGeoConstructor(GeoPoint geo)
        {
            this.geo = geo;
        }


        public Constructor Constructor
        {
            get { return Constructor.messageMediaGeo; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x56e0d474);
            this.geo.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            this.geo = Tl.Parse<GeoPoint>(reader);
        }

        public override string ToString()
        {
            return String.Format("(messageMediaGeo geo:{0})", geo);
        }
    }
}