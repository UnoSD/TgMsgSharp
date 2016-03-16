using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class Help_appUpdateConstructor : help_AppUpdate
    {
        public int id;
        public bool critical;
        public string url;
        public string text;

        public Help_appUpdateConstructor()
        {

        }

        public Help_appUpdateConstructor(int id, bool critical, string url, string text)
        {
            this.id = id;
            this.critical = critical;
            this.url = url;
            this.text = text;
        }


        public Constructor Constructor
        {
            get { return Constructor.help_appUpdate; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x8987f311);
            writer.Write(this.id);
            writer.Write(this.critical ? 0x997275b5 : 0xbc799737);
            Serializers.String.write(writer, this.url);
            Serializers.String.write(writer, this.text);
        }

        public override void Read(BinaryReader reader)
        {
            this.id = reader.ReadInt32();
            this.critical = reader.ReadUInt32() == 0x997275b5;
            this.url = Serializers.String.read(reader);
            this.text = Serializers.String.read(reader);
        }

        public override string ToString()
        {
            return String.Format("(help_appUpdate id:{0} critical:{1} url:'{2}' text:'{3}')", id, critical, url, text);
        }
    }
}