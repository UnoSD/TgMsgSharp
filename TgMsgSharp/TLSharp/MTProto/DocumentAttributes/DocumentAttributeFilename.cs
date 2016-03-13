using System.IO;

namespace TLSharp.Core.MTProto
{
    public class DocumentAttributeFilename : DocumentAttribute
    {
        public static Combinator Combinator => new Combinator(0x15590068);

        public string FileName { get; set; }

        public override void Write(BinaryWriter writer)
        {
            throw new System.NotImplementedException();
        }

        public override void Read(BinaryReader reader)
        {
            this.FileName = Serializers.String.read(reader);
        }
    }
}