using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class InputMediaVideoConstructor : InputMedia
    {
        public InputVideo id;

        public InputMediaVideoConstructor()
        {

        }

        public InputMediaVideoConstructor(InputVideo id)
        {
            this.id = id;
        }


        public Constructor Constructor
        {
            get { return Constructor.inputMediaVideo; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x7f023ae6);
            this.id.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            this.id = Tl.Parse<InputVideo>(reader);
        }

        public override string ToString()
        {
            return String.Format("(inputMediaVideo id:{0})", id);
        }
    }
}