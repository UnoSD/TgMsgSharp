using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class ChatFullConstructor : ChatFull
    {
        public int id;
        public ChatParticipants participants;
        public Photo chat_photo;
        public PeerNotifySettings notify_settings;

        public ChatFullConstructor()
        {

        }

        public ChatFullConstructor(int id, ChatParticipants participants, Photo chat_photo, PeerNotifySettings notify_settings)
        {
            this.id = id;
            this.participants = participants;
            this.chat_photo = chat_photo;
            this.notify_settings = notify_settings;
        }


        public Constructor Constructor
        {
            get { return Constructor.chatFull; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x630e61be);
            writer.Write(this.id);
            this.participants.Write(writer);
            this.chat_photo.Write(writer);
            this.notify_settings.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            this.id = reader.ReadInt32();
            this.participants = Tl.Parse<ChatParticipants>(reader);
            this.chat_photo = Tl.Parse<Photo>(reader);
            this.notify_settings = Tl.Parse<PeerNotifySettings>(reader);
        }

        public override string ToString()
        {
            return String.Format("(chatFull id:{0} participants:{1} chat_photo:{2} notify_settings:{3})", id, participants,
                chat_photo, notify_settings);
        }
    }
}