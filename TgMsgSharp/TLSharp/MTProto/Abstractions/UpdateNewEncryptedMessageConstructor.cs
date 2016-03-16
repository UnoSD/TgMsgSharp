using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class UpdateNewEncryptedMessageConstructor : Update
    {
        public EncryptedMessage message;
        public int qts;

        public UpdateNewEncryptedMessageConstructor()
        {

        }

        public UpdateNewEncryptedMessageConstructor(EncryptedMessage message, int qts)
        {
            this.message = message;
            this.qts = qts;
        }


        public Constructor Constructor
        {
            get { return Constructor.updateNewEncryptedMessage; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x12bcbd9a);
            this.message.Write(writer);
            writer.Write(this.qts);
        }

        public override void Read(BinaryReader reader)
        {
            this.message = Tl.Parse<EncryptedMessage>(reader);
            this.qts = reader.ReadInt32();
        }

        public override string ToString()
        {
            return String.Format("(updateNewEncryptedMessage message:{0} qts:{1})", message, qts);
        }
    }
}