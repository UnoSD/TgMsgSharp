using System;
using System.Collections.Generic;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class Contacts_blockedConstructor : contacts_Blocked
    {
        public List<ContactBlocked> blocked;
        public List<User> users;

        public Contacts_blockedConstructor()
        {

        }

        public Contacts_blockedConstructor(List<ContactBlocked> blocked, List<User> users)
        {
            this.blocked = blocked;
            this.users = users;
        }


        public Constructor Constructor
        {
            get { return Constructor.contacts_blocked; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x1c138d15);
            writer.Write(0x1cb5c415);
            writer.Write(this.blocked.Count);
            foreach (ContactBlocked blocked_element in this.blocked)
            {
                blocked_element.Write(writer);
            }
            writer.Write(0x1cb5c415);
            writer.Write(this.users.Count);
            foreach (User users_element in this.users)
            {
                users_element.Write(writer);
            }
        }

        public override void Read(BinaryReader reader)
        {
            reader.ReadInt32(); // vector code
            int blocked_len = reader.ReadInt32();
            this.blocked = new List<ContactBlocked>(blocked_len);
            for (int blocked_index = 0; blocked_index < blocked_len; blocked_index++)
            {
                ContactBlocked blocked_element;
                blocked_element = Tl.Parse<ContactBlocked>(reader);
                this.blocked.Add(blocked_element);
            }
            reader.ReadInt32(); // vector code
            int users_len = reader.ReadInt32();
            this.users = new List<User>(users_len);
            for (int users_index = 0; users_index < users_len; users_index++)
            {
                User users_element;
                users_element = Tl.Parse<User>(reader);
                this.users.Add(users_element);
            }
        }

        public override string ToString()
        {
            return String.Format("(contacts_blocked blocked:{0} users:{1})", Serializers.VectorToString(blocked),
                Serializers.VectorToString(users));
        }
    }
}