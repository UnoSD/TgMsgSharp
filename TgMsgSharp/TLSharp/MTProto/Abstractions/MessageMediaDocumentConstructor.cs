using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class MessageMediaDocumentConstructor : MessageMedia
    {
        public Document document;

        public MessageMediaDocumentConstructor()
        {

        }

        public MessageMediaDocumentConstructor(Document document)
        {
            this.document = document;
        }


        public Constructor Constructor
        {
            get { return Constructor.messageMediaDocument; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x2fda2204);
            this.document.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            this.document = Tl.Parse<Document>(reader);
        }

        public override string ToString()
        {
            return String.Format("(messageMediaDocument document:{0})", document);
        }
    }
}