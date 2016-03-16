using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class UpdateNewMessageConstructor : Update
    {
        public Message message;
        public int pts;

        public UpdateNewMessageConstructor()
        {

        }

        public UpdateNewMessageConstructor(Message message, int pts)
        {
            this.message = message;
            this.pts = pts;
        }


        public Constructor Constructor
        {
            get { return Constructor.updateNewMessage; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x013abdb3);
            this.message.Write(writer);
            writer.Write(this.pts);
        }

        public override void Read(BinaryReader reader)
        {
            this.message = Tl.Parse<Message>(reader);
            this.pts = reader.ReadInt32();
        }

        public override string ToString()
        {
            return String.Format("(updateNewMessage message:{0} pts:{1})", message, pts);
        }
    }
}