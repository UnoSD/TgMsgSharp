using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class UpdateActivationConstructor : Update
    {
        public int user_id;

        public UpdateActivationConstructor()
        {

        }

        public UpdateActivationConstructor(int user_id)
        {
            this.user_id = user_id;
        }


        public Constructor Constructor
        {
            get { return Constructor.updateActivation; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x6f690963);
            writer.Write(this.user_id);
        }

        public override void Read(BinaryReader reader)
        {
            this.user_id = reader.ReadInt32();
        }

        public override string ToString()
        {
            return String.Format("(updateActivation user_id:{0})", user_id);
        }
    }
}