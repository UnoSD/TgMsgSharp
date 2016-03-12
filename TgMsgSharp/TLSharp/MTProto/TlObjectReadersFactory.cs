using System;
using System.Collections.Generic;

namespace TLSharp.Core.MTProto
{
    public class TlObjectReadersFactory
    {
        readonly IDictionary<Type, ITlObjectReader> _readers;

        public TlObjectReadersFactory()
        {
            _readers = new Dictionary<Type, ITlObjectReader>
            {
                [typeof(MessageConstructor)] = new TlObjectReaderCommon(),
            };
        }

        public ITlObjectReader GetReader(Type type)
        {
            ITlObjectReader reader;

            _readers.TryGetValue(type, out reader);

            return reader;
        }
    }
}