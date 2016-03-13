using System.IO;

namespace TLSharp.Core.MTProto
{
    public class DocumentAttributeAudio : DocumentAttribute
    {
        public static Combinator Combinator => new Combinator(0x51448e5);

        public override void Write(BinaryWriter writer)
        {
            throw new System.NotImplementedException();
        }

        public override void Read(BinaryReader reader)
        {
            this.Duration = reader.ReadInt32();
        }

        public int Duration { get; set; }
    }
}