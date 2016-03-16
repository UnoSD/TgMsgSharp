using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class NearestDcConstructor : NearestDc
    {
        public string country;
        public int this_dc;
        public int nearest_dc;

        public NearestDcConstructor()
        {

        }

        public NearestDcConstructor(string country, int this_dc, int nearest_dc)
        {
            this.country = country;
            this.this_dc = this_dc;
            this.nearest_dc = nearest_dc;
        }


        public Constructor Constructor
        {
            get { return Constructor.nearestDc; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x8e1a1775);
            Serializers.String.write(writer, this.country);
            writer.Write(this.this_dc);
            writer.Write(this.nearest_dc);
        }

        public override void Read(BinaryReader reader)
        {
            this.country = Serializers.String.read(reader);
            this.this_dc = reader.ReadInt32();
            this.nearest_dc = reader.ReadInt32();
        }

        public override string ToString()
        {
            return String.Format("(nearestDc country:'{0}' this_dc:{1} nearest_dc:{2})", country, this_dc, nearest_dc);
        }
    }
}