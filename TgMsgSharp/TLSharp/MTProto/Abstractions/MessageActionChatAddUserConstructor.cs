using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class MessageActionChatAddUserConstructor : MessageAction
    {
        public int user_id;

        public MessageActionChatAddUserConstructor()
        {

        }

        public MessageActionChatAddUserConstructor(int user_id)
        {
            this.user_id = user_id;
        }


        public Constructor Constructor
        {
            get { return Constructor.messageActionChatAddUser; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x5e3cfc4b);
            writer.Write(this.user_id);
        }

        public override void Read(BinaryReader reader)
        {
            this.user_id = reader.ReadInt32();
        }

        public override string ToString()
        {
            return String.Format("(messageActionChatAddUser user_id:{0})", user_id);
        }
    }
}