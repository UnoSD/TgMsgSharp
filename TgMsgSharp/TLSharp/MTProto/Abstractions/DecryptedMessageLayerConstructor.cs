using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class DecryptedMessageLayerConstructor : DecryptedMessageLayer
    {
        public int layer;
        public DecryptedMessage message;

        public DecryptedMessageLayerConstructor()
        {

        }

        public DecryptedMessageLayerConstructor(int layer, DecryptedMessage message)
        {
            this.layer = layer;
            this.message = message;
        }


        public Constructor Constructor
        {
            get { return Constructor.decryptedMessageLayer; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x99a438cf);
            writer.Write(this.layer);
            this.message.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            this.layer = reader.ReadInt32();
            this.message = Tl.Parse<DecryptedMessage>(reader);
        }

        public override string ToString()
        {
            return String.Format("(decryptedMessageLayer layer:{0} message:{1})", layer, message);
        }
    }
}