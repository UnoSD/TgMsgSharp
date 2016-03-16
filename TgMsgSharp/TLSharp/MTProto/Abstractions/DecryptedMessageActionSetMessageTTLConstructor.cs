using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class DecryptedMessageActionSetMessageTTLConstructor : DecryptedMessageAction
    {
        public int ttl_seconds;

        public DecryptedMessageActionSetMessageTTLConstructor()
        {

        }

        public DecryptedMessageActionSetMessageTTLConstructor(int ttl_seconds)
        {
            this.ttl_seconds = ttl_seconds;
        }


        public Constructor Constructor
        {
            get { return Constructor.decryptedMessageActionSetMessageTTL; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xa1733aec);
            writer.Write(this.ttl_seconds);
        }

        public override void Read(BinaryReader reader)
        {
            this.ttl_seconds = reader.ReadInt32();
        }

        public override string ToString()
        {
            return String.Format("(decryptedMessageActionSetMessageTTL ttl_seconds:{0})", ttl_seconds);
        }
    }
}