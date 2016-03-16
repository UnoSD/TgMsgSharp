using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class GeoChatConstructor : Chat
    {
        public int id;
        public long access_hash;
        public string title;
        public string address;
        public string venue;
        public GeoPoint geo;
        public ChatPhoto photo;
        public int participants_count;
        public int date;
        public bool checked_in;
        public int version;

        public GeoChatConstructor()
        {

        }

        public GeoChatConstructor(int id, long access_hash, string title, string address, string venue, GeoPoint geo,
            ChatPhoto photo, int participants_count, int date, bool checked_in, int version)
        {
            this.id = id;
            this.access_hash = access_hash;
            this.title = title;
            this.address = address;
            this.venue = venue;
            this.geo = geo;
            this.photo = photo;
            this.participants_count = participants_count;
            this.date = date;
            this.checked_in = checked_in;
            this.version = version;
        }


        public Constructor Constructor
        {
            get { return Constructor.geoChat; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x75eaea5a);
            writer.Write(this.id);
            writer.Write(this.access_hash);
            Serializers.String.write(writer, this.title);
            Serializers.String.write(writer, this.address);
            Serializers.String.write(writer, this.venue);
            this.geo.Write(writer);
            this.photo.Write(writer);
            writer.Write(this.participants_count);
            writer.Write(this.date);
            writer.Write(this.checked_in ? 0x997275b5 : 0xbc799737);
            writer.Write(this.version);
        }

        public override void Read(BinaryReader reader)
        {
            this.id = reader.ReadInt32();
            this.access_hash = reader.ReadInt64();
            this.title = Serializers.String.read(reader);
            this.address = Serializers.String.read(reader);
            this.venue = Serializers.String.read(reader);
            this.geo = Tl.Parse<GeoPoint>(reader);
            this.photo = Tl.Parse<ChatPhoto>(reader);
            this.participants_count = reader.ReadInt32();
            this.date = reader.ReadInt32();
            this.checked_in = reader.ReadUInt32() == 0x997275b5;
            this.version = reader.ReadInt32();
        }

        public override string ToString()
        {
            return
                String.Format(
                    "(geoChat id:{0} access_hash:{1} title:'{2}' address:'{3}' venue:'{4}' geo:{5} photo:{6} participants_count:{7} date:{8} checked_in:{9} version:{10})",
                    id, access_hash, title, address, venue, geo, photo, participants_count, date, checked_in, version);
        }
    }
}