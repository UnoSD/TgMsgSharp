using System;
using System.IO;
using TLSharp.Core.MTProto;
using TLSharp.Core.MTProto.Crypto;
using TLSharp.Core.Requests;

namespace TLSharp.Core
{
    public class GetContactsRequest : MTProtoRequest
    {
        readonly string _hash;

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
            throw new NotImplementedException();
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
    }
}