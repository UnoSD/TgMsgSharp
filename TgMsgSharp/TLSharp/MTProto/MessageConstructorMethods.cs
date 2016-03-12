using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public partial class MessageConstructor
    {
        public bool Unread => Flags.HasFlag(MessageFlag.Unread);
        public bool Output => Flags.HasFlag(MessageFlag.SentByCurrentUser);

        public override void Write(BinaryWriter writer)
        {
            throw new NotImplementedException();
            //writer.Write(0x22eb6aba);
            //writer.Write(this.Id);
            //writer.Write(this.FromId);
            //writer.Write(this.ToId);
            //writer.Write(this.Output ? 0x997275b5 : 0xbc799737);
            //writer.Write(this.Unread ? 0x997275b5 : 0xbc799737);
            //writer.Write(this.Date);
            //Serializers.String.write(writer, this.Message);
            //this.Media.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            throw new NotImplementedException();
        }
    }
}