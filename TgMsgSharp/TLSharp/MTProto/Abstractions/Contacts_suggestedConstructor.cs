using System;
using System.Collections.Generic;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class Contacts_suggestedConstructor : contacts_Suggested
    {
        public List<ContactSuggested> results;
        public List<User> users;

        public Contacts_suggestedConstructor()
        {

        }

        public Contacts_suggestedConstructor(List<ContactSuggested> results, List<User> users)
        {
            this.results = results;
            this.users = users;
        }


        public Constructor Constructor
        {
            get { return Constructor.contacts_suggested; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x5649dcc5);
            writer.Write(0x1cb5c415);
            writer.Write(this.results.Count);
            foreach (ContactSuggested results_element in this.results)
            {
                results_element.Write(writer);
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
            int results_len = reader.ReadInt32();
            this.results = new List<ContactSuggested>(results_len);
            for (int results_index = 0; results_index < results_len; results_index++)
            {
                ContactSuggested results_element;
                results_element = Tl.Parse<ContactSuggested>(reader);
                this.results.Add(results_element);
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
            return String.Format("(contacts_suggested results:{0} users:{1})", Serializers.VectorToString(results),
                Serializers.VectorToString(users));
        }
    }
}