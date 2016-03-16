using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class InputUserForeignConstructor : InputUser
    {
        public int user_id;
        public long access_hash;

        public InputUserForeignConstructor()
        {

        }

        public InputUserForeignConstructor(int user_id, long access_hash)
        {
            this.user_id = user_id;
            this.access_hash = access_hash;
        }


        public Constructor Constructor
        {
            get { return Constructor.inputUserForeign; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x655e74ff);
            writer.Write(this.user_id);
            writer.Write(this.access_hash);
        }

        public override void Read(BinaryReader reader)
        {
            this.user_id = reader.ReadInt32();
            this.access_hash = reader.ReadInt64();
        }

        public override string ToString()
        {
            return String.Format("(inputUserForeign user_id:{0} access_hash:{1})", user_id, access_hash);
        }
    }
}