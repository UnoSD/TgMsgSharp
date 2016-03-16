using System;
using System.Collections.Generic;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class Contacts_contactsConstructor : contacts_Contacts
    {
        public List<Contact> contacts;
        public List<User> users;

        public Contacts_contactsConstructor()
        {

        }

        public Contacts_contactsConstructor(List<Contact> contacts, List<User> users)
        {
            this.contacts = contacts;
            this.users = users;
        }


        public Constructor Constructor
        {
            get { return Constructor.contacts_contacts; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x6f8b8cb2);
            writer.Write(0x1cb5c415);
            writer.Write(this.contacts.Count);
            foreach (Contact contacts_element in this.contacts)
            {
                contacts_element.Write(writer);
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
            int contacts_len = reader.ReadInt32();
            this.contacts = new List<Contact>(contacts_len);
            for (int contacts_index = 0; contacts_index < contacts_len; contacts_index++)
            {
                Contact contacts_element;
                contacts_element = Tl.Parse<Contact>(reader);
                this.contacts.Add(contacts_element);
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
            return String.Format("(contacts_contacts contacts:{0} users:{1})", Serializers.VectorToString(contacts),
                Serializers.VectorToString(users));
        }
    }
}