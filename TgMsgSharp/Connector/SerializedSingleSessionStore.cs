using System.IO;
using System.Xml.Serialization;
using TLSharp.Core;

namespace TgMsgSharp.Connector
{
    class SerializedSingleSessionStore : ISessionStore
    {
        readonly string _sessionUserId;
        
        readonly XmlSerializer _xmlSerializer = new XmlSerializer(typeof(Session));

        public string SessionData { get; private set; }

        public SerializedSingleSessionStore(string sessionUserId, string sessionData)
        {
            _sessionUserId = sessionUserId;
            SessionData = sessionData;
        }

        public void Save(Session session)
        {
            using (var stringWriter = new StringWriter())
            {
                _xmlSerializer.Serialize(stringWriter, session);
                SessionData = stringWriter.ToString();
            }
        }

        public Session Load(string sessionUserId)
        {
            if (sessionUserId != _sessionUserId) return null;

            using(var stringReader = new StringReader(SessionData))
                return _xmlSerializer.Deserialize(stringReader) as Session;
        }
    }
}