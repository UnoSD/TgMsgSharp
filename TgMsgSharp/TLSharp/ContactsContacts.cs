using System.Collections.Generic;
using TLSharp.Core.MTProto;

namespace TLSharp.Core
{
    public interface IGetContactsResponse : ITlResponse
    {
    }

    public interface ITlResponse : ITlObject
    {
    }

    public interface ITlObject
    {
    }
    
    public class ContactsContacts : IGetContactsResponse
    {
        public static Combinator Combinator => new Combinator(0x6f8b8cb2);

        public List<Contact> Contacts;
        public List<User> Users;
    }

    public class ContactsContactsNotModified : IGetContactsResponse
    {
        public static Combinator Combinator => new Combinator(0xb74ba9d2);
    }
}