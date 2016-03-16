using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class UpdateUserTypingConstructor : Update
    {
        public int user_id;

        public UpdateUserTypingConstructor()
        {

        }

        public UpdateUserTypingConstructor(int user_id)
        {
            this.user_id = user_id;
        }


        public Constructor Constructor
        {
            get { return Constructor.updateUserTyping; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x6baa8508);
            writer.Write(this.user_id);
        }

        public override void Read(BinaryReader reader)
        {
            this.user_id = reader.ReadInt32();
        }

        public override string ToString()
        {
            return String.Format("(updateUserTyping user_id:{0})", user_id);
        }
    }
}