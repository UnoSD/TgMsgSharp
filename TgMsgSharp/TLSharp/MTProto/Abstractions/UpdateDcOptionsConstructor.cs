using System;
using System.Collections.Generic;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class UpdateDcOptionsConstructor : Update
    {
        public List<DcOption> dc_options;

        public UpdateDcOptionsConstructor()
        {

        }

        public UpdateDcOptionsConstructor(List<DcOption> dc_options)
        {
            this.dc_options = dc_options;
        }


        public Constructor Constructor
        {
            get { return Constructor.updateDcOptions; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x8e5e9873);
            writer.Write(0x1cb5c415);
            writer.Write(this.dc_options.Count);
            foreach (DcOption dc_options_element in this.dc_options)
            {
                dc_options_element.Write(writer);
            }
        }

        public override void Read(BinaryReader reader)
        {
            reader.ReadInt32(); // vector code
            int dc_options_len = reader.ReadInt32();
            this.dc_options = new List<DcOption>(dc_options_len);
            for (int dc_options_index = 0; dc_options_index < dc_options_len; dc_options_index++)
            {
                DcOption dc_options_element;
                dc_options_element = Tl.Parse<DcOption>(reader);
                this.dc_options.Add(dc_options_element);
            }
        }

        public override string ToString()
        {
            return String.Format("(updateDcOptions dc_options:{0})", Serializers.VectorToString(dc_options));
        }
    }
}