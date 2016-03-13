using System.IO;

namespace TLSharp.Core.MTProto
{
    public class DocumentAttributeSticker : DocumentAttribute
    {
        public static Combinator Combinator => new Combinator(0xfb0a5727);

        public override void Write(BinaryWriter writer)
        {
            throw new System.NotImplementedException();
        }

        public override void Read(BinaryReader reader)
        {
        }
    }
}