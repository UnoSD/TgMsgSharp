using System.IO;

namespace TLSharp.Core.MTProto
{
    public class DocumentAttributeAnimated : DocumentAttribute
    {
        public static Combinator Combinator => new Combinator(0x11b58939);

        public override void Write(BinaryWriter writer)
        {
            throw new System.NotImplementedException();
        }

        public override void Read(BinaryReader reader)
        {
        }
    }
}