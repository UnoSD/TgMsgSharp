using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using TLSharp.Core.MTProto;
using TLSharp.Core.MTProto.Crypto;
using TLSharp.Core.Requests;

namespace TLSharp.Core
{
    public class GetContactsRequest : MTProtoRequest
    {
        // Input
        readonly string _hash;

        // Output
        public List<Contact> Contacts;
        public List<User> Users;

        public GetContactsRequest(string hash)
        {
            _hash = hash;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0x22c6aa08);
            var md5String = MD5.GetMd5String(_hash);
            Serializers.String.write(writer, md5String);
        }

        public override void OnResponse(BinaryReader reader)
        {
            var combinator = new Combinator(reader.ReadUInt32());

            if(combinator.ToType != typeof(Contacts_contactsConstructor))
                Debugger.Break();
            
            // contacts
            var contactsCombinator = new Combinator(reader.ReadUInt32()); // vector #1cb5c415
            
            var count = reader.ReadInt32();

            Contacts = new List<Contact>(count);

            for (var index = 0; index < count; index++)
            {
                var contact = TL.Parse<Contact>(reader);

                Contacts.Add(contact);
            }


			// users
			var usersCombinator = new Combinator(reader.ReadUInt32()); // vector #1cb5c415

            count = reader.ReadInt32();

			Users = new List<User>(count);

			for (var index = 0; index < count; index++)
			{
			    var user = TL.Parse<User>(reader);

			    Users.Add(user);
			}
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
    }
}