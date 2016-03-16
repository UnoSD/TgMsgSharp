using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class UpdateNewGeoChatMessageConstructor : Update
    {
        public GeoChatMessage message;

        public UpdateNewGeoChatMessageConstructor()
        {

        }

        public UpdateNewGeoChatMessageConstructor(GeoChatMessage message)
        {
            this.message = message;
        }


        public Constructor Constructor
        {
            get { return Constructor.updateNewGeoChatMessage; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x5a68e3f7);
            this.message.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            this.message = Tl.Parse<GeoChatMessage>(reader);
        }

        public override string ToString()
        {
            return String.Format("(updateNewGeoChatMessage message:{0})", message);
        }
    }
}