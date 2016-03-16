using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class InputFileLocationConstructor : InputFileLocation
    {
        public long volume_id;
        public int local_id;
        public long secret;

        public InputFileLocationConstructor()
        {

        }

        public InputFileLocationConstructor(long volume_id, int local_id, long secret)
        {
            this.volume_id = volume_id;
            this.local_id = local_id;
            this.secret = secret;
        }


        public Constructor Constructor
        {
            get { return Constructor.inputFileLocation; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x14637196);
            writer.Write(this.volume_id);
            writer.Write(this.local_id);
            writer.Write(this.secret);
        }

        public override void Read(BinaryReader reader)
        {
            this.volume_id = reader.ReadInt64();
            this.local_id = reader.ReadInt32();
            this.secret = reader.ReadInt64();
        }

        public override string ToString()
        {
            return String.Format("(inputFileLocation volume_id:{0} local_id:{1} secret:{2})", volume_id, local_id, secret);
        }
    }
}