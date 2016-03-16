using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class InputMediaDocumentConstructor : InputMedia
    {
        public InputDocument id;

        public InputMediaDocumentConstructor()
        {

        }

        public InputMediaDocumentConstructor(InputDocument id)
        {
            this.id = id;
        }


        public Constructor Constructor
        {
            get { return Constructor.inputMediaDocument; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xd184e841);
            this.id.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            this.id = Tl.Parse<InputDocument>(reader);
        }

        public override string ToString()
        {
            return String.Format("(inputMediaDocument id:{0})", id);
        }
    }
}