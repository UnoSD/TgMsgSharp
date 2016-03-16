using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class MessageMediaAudioConstructor : MessageMedia
    {
        public Audio audio;

        public MessageMediaAudioConstructor()
        {

        }

        public MessageMediaAudioConstructor(Audio audio)
        {
            this.audio = audio;
        }


        public Constructor Constructor
        {
            get { return Constructor.messageMediaAudio; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xc6b68300);
            this.audio.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            this.audio = Tl.Parse<Audio>(reader);
        }

        public override string ToString()
        {
            return String.Format("(messageMediaAudio audio:{0})", audio);
        }
    }
}