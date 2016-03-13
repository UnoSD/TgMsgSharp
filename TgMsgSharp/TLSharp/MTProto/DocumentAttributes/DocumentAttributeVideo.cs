using System.IO;

namespace TLSharp.Core.MTProto
{
    public class DocumentAttributeVideo : DocumentAttribute
    {
        public static Combinator Combinator => new Combinator(0x5910cccb);

        public override void Write(BinaryWriter writer)
        {
            throw new System.NotImplementedException();
        }

        public override void Read(BinaryReader reader)
        {
            this.Duration = reader.ReadInt32();
            this.Width = reader.ReadInt32();
            this.Height = reader.ReadInt32();
        }

        public int Height { get; set; }

        public int Width { get; set; }

        public int Duration { get; set; }
    }
}