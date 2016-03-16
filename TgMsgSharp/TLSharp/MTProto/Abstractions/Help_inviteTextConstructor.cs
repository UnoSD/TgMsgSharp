using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class Help_inviteTextConstructor : help_InviteText
    {
        public string message;

        public Help_inviteTextConstructor()
        {

        }

        public Help_inviteTextConstructor(string message)
        {
            this.message = message;
        }


        public Constructor Constructor
        {
            get { return Constructor.help_inviteText; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x18cb9f78);
            Serializers.String.write(writer, this.message);
        }

        public override void Read(BinaryReader reader)
        {
            this.message = Serializers.String.read(reader);
        }

        public override string ToString()
        {
            return String.Format("(help_inviteText message:'{0}')", message);
        }
    }
}