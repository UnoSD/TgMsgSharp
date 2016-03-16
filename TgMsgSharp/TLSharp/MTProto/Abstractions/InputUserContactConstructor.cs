using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class InputUserContactConstructor : InputUser
    {
        public int user_id;

        public InputUserContactConstructor()
        {

        }

        public InputUserContactConstructor(int user_id)
        {
            this.user_id = user_id;
        }


        public Constructor Constructor
        {
            get { return Constructor.inputUserContact; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x86e94f65);
            writer.Write(this.user_id);
        }

        public override void Read(BinaryReader reader)
        {
            this.user_id = reader.ReadInt32();
        }

        public override string ToString()
        {
            return String.Format("(inputUserContact user_id:{0})", user_id);
        }
    }
}