using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class MessageActionChatDeleteUserConstructor : MessageAction
    {
        public int user_id;

        public MessageActionChatDeleteUserConstructor()
        {

        }

        public MessageActionChatDeleteUserConstructor(int user_id)
        {
            this.user_id = user_id;
        }


        public Constructor Constructor
        {
            get { return Constructor.messageActionChatDeleteUser; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xb2ae9b0c);
            writer.Write(this.user_id);
        }

        public override void Read(BinaryReader reader)
        {
            this.user_id = reader.ReadInt32();
        }

        public override string ToString()
        {
            return String.Format("(messageActionChatDeleteUser user_id:{0})", user_id);
        }
    }
}