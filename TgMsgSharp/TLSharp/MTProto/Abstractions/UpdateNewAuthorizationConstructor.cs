using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class UpdateNewAuthorizationConstructor : Update
    {
        public long auth_key_id;
        public int date;
        public string device;
        public string location;

        public UpdateNewAuthorizationConstructor()
        {

        }

        public UpdateNewAuthorizationConstructor(long auth_key_id, int date, string device, string location)
        {
            this.auth_key_id = auth_key_id;
            this.date = date;
            this.device = device;
            this.location = location;
        }


        public Constructor Constructor
        {
            get { return Constructor.updateNewAuthorization; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x8f06529a);
            writer.Write(this.auth_key_id);
            writer.Write(this.date);
            Serializers.String.write(writer, this.device);
            Serializers.String.write(writer, this.location);
        }

        public override void Read(BinaryReader reader)
        {
            this.auth_key_id = reader.ReadInt64();
            this.date = reader.ReadInt32();
            this.device = Serializers.String.read(reader);
            this.location = Serializers.String.read(reader);
        }

        public override string ToString()
        {
            return String.Format("(updateNewAuthorization auth_key_id:{0} date:{1} device:'{2}' location:'{3}')", auth_key_id,
                date, device, location);
        }
    }
}