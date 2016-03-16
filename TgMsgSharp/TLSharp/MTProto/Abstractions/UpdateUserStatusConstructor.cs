using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class UpdateUserStatusConstructor : Update
    {
        public int user_id;
        public UserStatus status;

        public UpdateUserStatusConstructor()
        {

        }

        public UpdateUserStatusConstructor(int user_id, UserStatus status)
        {
            this.user_id = user_id;
            this.status = status;
        }


        public Constructor Constructor
        {
            get { return Constructor.updateUserStatus; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x1bfbd823);
            writer.Write(this.user_id);
            this.status.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            this.user_id = reader.ReadInt32();
            this.status = Tl.Parse<UserStatus>(reader);
        }

        public override string ToString()
        {
            return String.Format("(updateUserStatus user_id:{0} status:{1})", user_id, status);
        }
    }
}