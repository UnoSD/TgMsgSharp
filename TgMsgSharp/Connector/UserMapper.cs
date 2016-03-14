using System.Collections.Generic;
using System.Linq;
using TgMsgSharp.Launcher;
using TLSharp.Core.MTProto;

namespace TgMsgSharp.Connector
{
    class UserMapper : IMapper<UserContactConstructor, TgContact>
    {
        public IEnumerable<TgContact> Map(IEnumerable<UserContactConstructor> users) => users.Select(Map);

        public TgContact Map(UserContactConstructor user)
        {
            return new TgContact
            {
                Id = user.id,
                Number = user.phone,
                FirstName = user.first_name,
                LastName = user.last_name
            };
        }
    }
}