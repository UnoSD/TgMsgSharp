using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class DcOptionConstructor : DcOption
    {
        public int id;
        public string hostname;
        public string ip_address;
        public int port;

        public DcOptionConstructor()
        {

        }

        public DcOptionConstructor(int id, string hostname, string ip_address, int port)
        {
            this.id = id;
            this.hostname = hostname;
            this.ip_address = ip_address;
            this.port = port;
        }


        public Constructor Constructor
        {
            get { return Constructor.dcOption; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x2ec2a43c);
            writer.Write(this.id);
            Serializers.String.write(writer, this.hostname);
            Serializers.String.write(writer, this.ip_address);
            writer.Write(this.port);
        }

        public override void Read(BinaryReader reader)
        {
            this.id = reader.ReadInt32();
            this.hostname = Serializers.String.read(reader);
            this.ip_address = Serializers.String.read(reader);
            this.port = reader.ReadInt32();
        }

        public override string ToString()
        {
            return String.Format("(dcOption id:{0} hostname:'{1}' ip_address:'{2}' port:{3})", id, hostname, ip_address, port);
        }
    }
}