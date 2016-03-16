using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class InputAudioEmptyConstructor : InputAudio
    {

        public InputAudioEmptyConstructor()
        {

        }



        public Constructor Constructor
        {
            get { return Constructor.inputAudioEmpty; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xd95adc84);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return String.Format("(inputAudioEmpty)");
        }
    }
}