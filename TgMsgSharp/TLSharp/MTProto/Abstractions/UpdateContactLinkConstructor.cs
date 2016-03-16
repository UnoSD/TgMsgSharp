using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class UpdateContactLinkConstructor : Update
    {
        public int user_id;
        public contacts_MyLink my_link;
        public contacts_ForeignLink foreign_link;

        public UpdateContactLinkConstructor()
        {

        }

        public UpdateContactLinkConstructor(int user_id, contacts_MyLink my_link, contacts_ForeignLink foreign_link)
        {
            this.user_id = user_id;
            this.my_link = my_link;
            this.foreign_link = foreign_link;
        }


        public Constructor Constructor
        {
            get { return Constructor.updateContactLink; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x51a48a9a);
            writer.Write(this.user_id);
            this.my_link.Write(writer);
            this.foreign_link.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            this.user_id = reader.ReadInt32();
            this.my_link = Tl.Parse<contacts_MyLink>(reader);
            this.foreign_link = Tl.Parse<contacts_ForeignLink>(reader);
        }

        public override string ToString()
        {
            return String.Format("(updateContactLink user_id:{0} my_link:{1} foreign_link:{2})", user_id, my_link, foreign_link);
        }
    }
}