using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class InputMediaUploadedAudioConstructor : InputMedia
    {
        public InputFile file;
        public int duration;

        public InputMediaUploadedAudioConstructor()
        {

        }

        public InputMediaUploadedAudioConstructor(InputFile file, int duration)
        {
            this.file = file;
            this.duration = duration;
        }


        public Constructor Constructor
        {
            get { return Constructor.inputMediaUploadedAudio; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x61a6d436);
            this.file.Write(writer);
            writer.Write(this.duration);
        }

        public override void Read(BinaryReader reader)
        {
            this.file = Tl.Parse<InputFile>(reader);
            this.duration = reader.ReadInt32();
        }

        public override string ToString()
        {
            return String.Format("(inputMediaUploadedAudio file:{0} duration:{1})", file, duration);
        }
    }
}