using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using TLSharp.Core.MTProto;

namespace TLSharp.Core.Network
{
    class ResponseHandlerFactory
    {
        public ITlResponseHandler GetHandler<T>()
        {
            return new TlResponseHandler();
        }
    }

    public interface ITlResponseHandler
    {
        ITlResponse Populate(BinaryReader compressedReader);
    }

    class TlResponseHandler : ITlResponseHandler
    {
        public ITlResponse Populate(BinaryReader reader)
        {
            var contactsContacts = new ContactsContacts();

            var combinator = new Combinator(reader.ReadUInt32());

            if (combinator.ToType != typeof(Contacts_contactsConstructor))
                Debugger.Break();

            // contacts
            var contactsCombinator = new Combinator(reader.ReadUInt32()); // vector #1cb5c415

            var count = reader.ReadInt32();

            contactsContacts.Contacts = new List<Contact>(count);

            for (var index = 0; index < count; index++)
            {
                var contact = TL.Parse<Contact>(reader);

                contactsContacts.Contacts.Add(contact);
            }


            // users
            var usersCombinator = new Combinator(reader.ReadUInt32()); // vector #1cb5c415

            count = reader.ReadInt32();

            contactsContacts.Users = new List<User>(count);

            for (var index = 0; index < count; index++)
            {
                var user = TL.Parse<User>(reader);

                contactsContacts.Users.Add(user);
            }

            return contactsContacts;
        }
    }
}