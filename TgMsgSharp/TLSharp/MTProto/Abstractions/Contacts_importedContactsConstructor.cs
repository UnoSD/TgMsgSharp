using System;
using System.Collections.Generic;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class Contacts_importedContactsConstructor : contacts_ImportedContacts
    {
        public List<ImportedContact> imported;
        public List<User> users;

        public Contacts_importedContactsConstructor()
        {

        }

        public Contacts_importedContactsConstructor(List<ImportedContact> imported, List<User> users)
        {
            this.imported = imported;
            this.users = users;
        }


        public Constructor Constructor
        {
            get { return Constructor.contacts_importedContacts; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xd1cd0a4c);
            writer.Write(0x1cb5c415);
            writer.Write(this.imported.Count);
            foreach (ImportedContact imported_element in this.imported)
            {
                imported_element.Write(writer);
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
            int imported_len = reader.ReadInt32();
            this.imported = new List<ImportedContact>(imported_len);
            for (int imported_index = 0; imported_index < imported_len; imported_index++)
            {
                ImportedContact imported_element;
                imported_element = Tl.Parse<ImportedContact>(reader);
                this.imported.Add(imported_element);
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
            return String.Format("(contacts_importedContacts imported:{0} users:{1})", Serializers.VectorToString(imported),
                Serializers.VectorToString(users));
        }
    }
}