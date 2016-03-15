using System.IO;
using System.Threading.Tasks;
using Ionic.Zlib;
using TLSharp.Core.MTProto;
using TLSharp.Core.Requests;

namespace TLSharp.Core.Network
{
    public partial class MtProtoSender
    {
        public async Task<T> Receive<T>(MTProtoRequest request) where T : class, ITlResponse
        {
            T response = null;

            while (!request.ConfirmReceived)
            {
                var tcpMessage = await _transport.Receieve();

                var result = DecodeMessage(tcpMessage.Body);

                using (var messageStream = new MemoryStream(result.Item1, false))
                using (var messageReader = new BinaryReader(messageStream))
                    response = ProcessMessage(result.Item2, messageReader, request) as T;
            }

            return response;
        }

        ITlResponse ProcessMessage(ulong messageId, BinaryReader messageReader, MTProtoRequest request)
        {
            ITlResponse response = null;

            needConfirmation.Add(messageId);

            var code = messageReader.ReadUInt32();

            messageReader.BaseStream.Position -= 4;

            if (code == 0xf35c6d01)
                response = HandleRpcResult(messageReader, request);

            return response;
        }

        static ITlResponse HandleRpcResult(BinaryReader messageReader, MTProtoRequest request)
        {
            var combinator = new Combinator(messageReader.ReadUInt32());

            var requestId = messageReader.ReadUInt64();

            if (requestId == (ulong)request.MessageId)
                request.ConfirmReceived = true;

            var innerCode = messageReader.ReadUInt32();

            if (innerCode != 0x3072cfa1) return null;

            ITlResponse response = null;

            var packedData = Serializers.Bytes.read(messageReader);

            var packedStream = new MemoryStream(packedData, false);

            var zipStream = new GZipStream(packedStream, CompressionMode.Decompress);

            var compressedReader = new BinaryReader(zipStream);

            var responseHandlerFactory = new ResponseHandlerFactory();

            var handler = responseHandlerFactory.GetHandler<ContactsContacts>();

            if (handler != null)
                response = handler.Populate(compressedReader);

            const int bufferSize = 4096;

            using (var memoryStream = new MemoryStream())
            {
                var buffer = new byte[bufferSize];

                int count;

                while ((count = compressedReader.Read(buffer, 0, buffer.Length)) != 0)
                    memoryStream.Write(buffer, 0, count);
            }

            compressedReader.Dispose();

            zipStream.Dispose();

            packedStream.Dispose();

            return response;
        }

    }
}