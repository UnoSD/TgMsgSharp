using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class MessageConstructor : Message
    {
        [Flags]
        public enum Flags : int
        {
            /*
                flags & 0x1 - message is unread (moved here from unread)
                flags & 0x2 - message was sent by the current user (moved here from out)
            */
            Unread = 1,
            SentByCurrentUser = 2
        }

        public int id;
        public int from_id;
        public int to_id;
        public bool output;
        public bool unread;
        public int date;
        public string message;
        public MessageMedia media;

        public Flags flags;

        public int chat_id;

        public MessageConstructor()
        {

        }

        public MessageConstructor(int id, int from_id, int to_id, bool output, bool unread, int date, string message,
            MessageMedia media)
        {
            this.id = id;
            this.from_id = from_id;
            this.to_id = to_id;
            this.output = output;
            this.unread = unread;
            this.date = date;
            this.message = message;
            this.media = media;
        }


        public override Constructor Constructor
        {
            get { return Constructor.message; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x22eb6aba);
            writer.Write(this.id);
            writer.Write(this.from_id);
            writer.Write(this.to_id);
            writer.Write(this.output ? 0x997275b5 : 0xbc799737);
            writer.Write(this.unread ? 0x997275b5 : 0xbc799737);
            writer.Write(this.date);
            Serializers.String.write(writer, this.message);
            this.media.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            //message#567699b3 flags:int id:int from_id:int to_id:Peer date:int message:string media:MessageMedia = Message;

            var flagsInt = reader.ReadInt32();

            this.flags = (Flags)flagsInt;
            this.unread = (flagsInt & (int)Flags.Unread) == (int)Flags.Unread;
            this.output = (flagsInt & (int)Flags.SentByCurrentUser) == (int)Flags.SentByCurrentUser;

            this.id = reader.ReadInt32();
            this.from_id = reader.ReadInt32();

            // Peer
            this.to_id = reader.ReadInt32();
            this.chat_id = reader.ReadInt32();

            this.date = reader.ReadInt32();
            this.message = Serializers.String.read(reader);
            this.media = TL.Parse<MessageMedia>(reader);
        }

        public override string ToString() => $"{message} - {media})";
    }
}