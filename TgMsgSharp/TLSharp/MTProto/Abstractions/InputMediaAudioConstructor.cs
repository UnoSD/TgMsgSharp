using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class InputMediaAudioConstructor : InputMedia
    {
        public InputAudio id;

        public InputMediaAudioConstructor()
        {

        }

        public InputMediaAudioConstructor(InputAudio id)
        {
            this.id = id;
        }


        public Constructor Constructor
        {
            get { return Constructor.inputMediaAudio; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x89938781);
            this.id.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            this.id = Tl.Parse<InputAudio>(reader);
        }

        public override string ToString()
        {
            return String.Format("(inputMediaAudio id:{0})", id);
        }
    }
}