using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class UpdateShortConstructor : Updates
    {
        public Update update;
        public int date;

        public UpdateShortConstructor()
        {

        }

        public UpdateShortConstructor(Update update, int date)
        {
            this.update = update;
            this.date = date;
        }


        public Constructor Constructor
        {
            get { return Constructor.updateShort; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x78d4dec1);
            this.update.Write(writer);
            writer.Write(this.date);
        }

        public override void Read(BinaryReader reader)
        {
            this.update = Tl.Parse<Update>(reader);
            this.date = reader.ReadInt32();
        }

        public override string ToString()
        {
            return String.Format("(updateShort update:{0} date:{1})", update, date);
        }
    }
}