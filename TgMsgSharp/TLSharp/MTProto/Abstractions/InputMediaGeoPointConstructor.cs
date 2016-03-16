using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class InputMediaGeoPointConstructor : InputMedia
    {
        public InputGeoPoint geo_point;

        public InputMediaGeoPointConstructor()
        {

        }

        public InputMediaGeoPointConstructor(InputGeoPoint geo_point)
        {
            this.geo_point = geo_point;
        }


        public Constructor Constructor
        {
            get { return Constructor.inputMediaGeoPoint; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xf9c44144);
            this.geo_point.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            this.geo_point = Tl.Parse<InputGeoPoint>(reader);
        }

        public override string ToString()
        {
            return String.Format("(inputMediaGeoPoint geo_point:{0})", geo_point);
        }
    }
}