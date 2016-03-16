using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class InputPhotoCropConstructor : InputPhotoCrop
    {
        public double crop_left;
        public double crop_top;
        public double crop_width;

        public InputPhotoCropConstructor()
        {

        }

        public InputPhotoCropConstructor(double crop_left, double crop_top, double crop_width)
        {
            this.crop_left = crop_left;
            this.crop_top = crop_top;
            this.crop_width = crop_width;
        }


        public Constructor Constructor
        {
            get { return Constructor.inputPhotoCrop; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xd9915325);
            writer.Write(this.crop_left);
            writer.Write(this.crop_top);
            writer.Write(this.crop_width);
        }

        public override void Read(BinaryReader reader)
        {
            this.crop_left = reader.ReadDouble();
            this.crop_top = reader.ReadDouble();
            this.crop_width = reader.ReadDouble();
        }

        public override string ToString()
        {
            return String.Format("(inputPhotoCrop crop_left:{0} crop_top:{1} crop_width:{2})", crop_left, crop_top, crop_width);
        }
    }
}