using System;
using System.Collections.Generic;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class ConfigConstructor : Config
    {
        public int date;
        public bool test_mode;
        public int this_dc;
        public List<DcOption> dc_options;
        public int chat_size_max;

        public ConfigConstructor()
        {

        }

        public ConfigConstructor(int date, bool test_mode, int this_dc, List<DcOption> dc_options, int chat_size_max)
        {
            this.date = date;
            this.test_mode = test_mode;
            this.this_dc = this_dc;
            this.dc_options = dc_options;
            this.chat_size_max = chat_size_max;
        }


        public Constructor Constructor
        {
            get { return Constructor.config; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x232d5905);
            writer.Write(this.date);
            writer.Write(this.test_mode ? 0x997275b5 : 0xbc799737);
            writer.Write(this.this_dc);
            writer.Write(0x1cb5c415);
            writer.Write(this.dc_options.Count);
            foreach (DcOption dc_options_element in this.dc_options)
            {
                dc_options_element.Write(writer);
            }
            writer.Write(this.chat_size_max);
        }

        public override void Read(BinaryReader reader)
        {
            this.date = reader.ReadInt32();
            var expires = reader.ReadInt32();
            this.test_mode = reader.ReadUInt32() == 0x997275b5;
            this.this_dc = reader.ReadInt32();
            reader.ReadInt32(); // vector code
            int dc_options_len = reader.ReadInt32();
            this.dc_options = new List<DcOption>(dc_options_len);
            for (int dc_options_index = 0; dc_options_index < dc_options_len; dc_options_index++)
            {
                DcOption dc_options_element;
                dc_options_element = Tl.Parse<DcOption>(reader);
                this.dc_options.Add(dc_options_element);
            }
            this.chat_size_max = reader.ReadInt32();
        }

        public override string ToString()
        {
            return String.Format("(config date:{0} test_mode:{1} this_dc:{2} dc_options:{3} chat_size_max:{4})", date, test_mode,
                this_dc, Serializers.VectorToString(dc_options), chat_size_max);
        }
    }
}