using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class FileLocationConstructor : FileLocation
    {
        public int dc_id;
        public long volume_id;
        public int local_id;
        public long secret;

        public FileLocationConstructor()
        {

        }

        public FileLocationConstructor(int dc_id, long volume_id, int local_id, long secret)
        {
            this.dc_id = dc_id;
            this.volume_id = volume_id;
            this.local_id = local_id;
            this.secret = secret;
        }


        public Constructor Constructor
        {
            get { return Constructor.fileLocation; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x53d69076);
            writer.Write(this.dc_id);
            writer.Write(this.volume_id);
            writer.Write(this.local_id);
            writer.Write(this.secret);
        }

        public override void Read(BinaryReader reader)
        {
            this.dc_id = reader.ReadInt32();
            this.volume_id = reader.ReadInt64();
            this.local_id = reader.ReadInt32();
            this.secret = reader.ReadInt64();
        }

        public override string ToString()
        {
            return String.Format("(fileLocation dc_id:{0} volume_id:{1} local_id:{2} secret:{3})", dc_id, volume_id, local_id,
                secret);
        }
    }
}