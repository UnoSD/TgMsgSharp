using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class AudioConstructor : Audio
    {
        public long Id { get; set; }
        public long AccessHash { get; set; }
        public int UserId { get; set; }
        public int Date { get; set; }
        public int Duration { get; set; }
        public int Size { get; set; }
        public int DcId { get; set; }
        public string MimeType { get; set; }

        public override void Write(BinaryWriter writer)
        {
            throw new NotImplementedException();
        }

        public override void Read(BinaryReader reader)
        {
            //audio#c7ac6496 id:long access_hash:long user_id:int date:int duration:int mime_type:string size:int dc_id:int = Audio;

            this.Id = reader.ReadInt64();
            this.AccessHash = reader.ReadInt64();
            this.UserId = reader.ReadInt32();
            this.Date = reader.ReadInt32();
            this.Duration = reader.ReadInt32();
            this.MimeType = Serializers.String.read(reader);
            this.Size = reader.ReadInt32();
            this.DcId = reader.ReadInt32();
        }
    }
}