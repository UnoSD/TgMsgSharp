using System.IO;

namespace TLSharp.Core.MTProto
{
    public class DocumentAttributeImageSize : DocumentAttribute
    {
        public static Combinator Combinator => new Combinator(0x6c37c15c);

        public override void Write(BinaryWriter writer)
        {
            throw new System.NotImplementedException();
        }

        public override void Read(BinaryReader reader)
        {
            this.Width = reader.ReadInt32();
            this.Height = reader.ReadInt32();
        }

        public int Height { get; set; }

        public int Width { get; set; }

    }
}