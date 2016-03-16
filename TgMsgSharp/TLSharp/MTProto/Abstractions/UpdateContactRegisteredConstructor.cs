using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class UpdateContactRegisteredConstructor : Update
    {
        public int user_id;
        public int date;

        public UpdateContactRegisteredConstructor()
        {

        }

        public UpdateContactRegisteredConstructor(int user_id, int date)
        {
            this.user_id = user_id;
            this.date = date;
        }


        public Constructor Constructor
        {
            get { return Constructor.updateContactRegistered; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x2575bbb9);
            writer.Write(this.user_id);
            writer.Write(this.date);
        }

        public override void Read(BinaryReader reader)
        {
            this.user_id = reader.ReadInt32();
            this.date = reader.ReadInt32();
        }

        public override string ToString()
        {
            return String.Format("(updateContactRegistered user_id:{0} date:{1})", user_id, date);
        }
    }
}