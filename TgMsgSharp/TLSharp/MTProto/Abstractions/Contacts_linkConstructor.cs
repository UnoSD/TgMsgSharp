using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class Contacts_linkConstructor : contacts_Link
    {
        public contacts_MyLink my_link;
        public contacts_ForeignLink foreign_link;
        public User user;

        public Contacts_linkConstructor()
        {

        }

        public Contacts_linkConstructor(contacts_MyLink my_link, contacts_ForeignLink foreign_link, User user)
        {
            this.my_link = my_link;
            this.foreign_link = foreign_link;
            this.user = user;
        }


        public Constructor Constructor
        {
            get { return Constructor.contacts_link; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xeccea3f5);
            this.my_link.Write(writer);
            this.foreign_link.Write(writer);
            this.user.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            this.my_link = Tl.Parse<contacts_MyLink>(reader);
            this.foreign_link = Tl.Parse<contacts_ForeignLink>(reader);
            this.user = Tl.Parse<User>(reader);
        }

        public override string ToString()
        {
            return String.Format("(contacts_link my_link:{0} foreign_link:{1} user:{2})", my_link, foreign_link, user);
        }
    }
}