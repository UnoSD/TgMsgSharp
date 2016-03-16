using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class InputAppEventConstructor : InputAppEvent
    {
        public double time;
        public string type;
        public long peer;
        public string data;

        public InputAppEventConstructor()
        {

        }

        public InputAppEventConstructor(double time, string type, long peer, string data)
        {
            this.time = time;
            this.type = type;
            this.peer = peer;
            this.data = data;
        }


        public Constructor Constructor
        {
            get { return Constructor.inputAppEvent; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x770656a8);
            writer.Write(this.time);
            Serializers.String.write(writer, this.type);
            writer.Write(this.peer);
            Serializers.String.write(writer, this.data);
        }

        public override void Read(BinaryReader reader)
        {
            this.time = reader.ReadDouble();
            this.type = Serializers.String.read(reader);
            this.peer = reader.ReadInt64();
            this.data = Serializers.String.read(reader);
        }

        public override string ToString()
        {
            return String.Format("(inputAppEvent time:{0} type:'{1}' peer:{2} data:'{3}')", time, type, peer, data);
        }
    }
}