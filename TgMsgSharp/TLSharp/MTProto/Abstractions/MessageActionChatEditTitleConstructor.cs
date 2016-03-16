using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class MessageActionChatEditTitleConstructor : MessageAction
    {
        public string title;

        public MessageActionChatEditTitleConstructor()
        {

        }

        public MessageActionChatEditTitleConstructor(string title)
        {
            this.title = title;
        }


        public Constructor Constructor
        {
            get { return Constructor.messageActionChatEditTitle; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xb5a1ce5a);
            Serializers.String.write(writer, this.title);
        }

        public override void Read(BinaryReader reader)
        {
            this.title = Serializers.String.read(reader);
        }

        public override string ToString()
        {
            return String.Format("(messageActionChatEditTitle title:'{0}')", title);
        }
    }
}