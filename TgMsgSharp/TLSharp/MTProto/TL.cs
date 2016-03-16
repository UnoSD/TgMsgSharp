using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;

namespace TLSharp.Core.MTProto
{
    public class Tl
    {
        static readonly TlObjectReadersFactory TlObjectReadersFactory = new TlObjectReadersFactory();
        static IReadOnlyCollection<Type> _cachedTypes;
        static IDictionary<uint, Type> _cachedCombinatorsLookup;

        public static TLObject Parse(BinaryReader reader, uint code)
        {
            if (!CombinatorsMap.Constructors.ContainsKey(code))
            {
                throw new Exception("unknown constructor code");
            }

            var dataCode = reader.ReadUInt32();

            if (dataCode != code)
            {
                throw new Exception($"target code {code} != data code {dataCode}");
            }

            var obj = (TLObject)Activator.CreateInstance(CombinatorsMap.Constructors[code]);
            obj.Read(reader);
            return obj;
        }

        public static T Parse<T>(BinaryReader reader)
        {
            if (typeof(TLObject).IsAssignableFrom(typeof(T)))
            {
                var dataCode = reader.ReadUInt32();

                var hexDataCode = new Combinator(dataCode);

                if (!typeof(T).IsAssignableFrom(hexDataCode.ToType))
                {
                    Debugger.Break();

                    throw new Exception($"try to parse {typeof(T).FullName}, but incompatible type {hexDataCode.ToType.FullName}");
                }

                T obj;

                var objectReader = TlObjectReadersFactory.GetReader(hexDataCode.ToType);

                if (objectReader != null)
                    obj = objectReader.Read<T>(reader, hexDataCode.ToType);
                else
                {
                    obj = (T)Activator.CreateInstance(hexDataCode.ToType);

                    ((TLObject)(object)obj).Read(reader);
                }

                return obj;
            }

            if (typeof(T) != typeof(bool)) throw new Exception("unknown return type");

            var code = reader.ReadUInt32();

            switch (code)
            {
                case 0x997275b5:
                    return (T)(object)true;
                case 0xbc799737:
                    return (T)(object)false;
                default:
                    throw new Exception("unknown bool value");
            }
        }
        public static Type GetCombinatorType(uint dataCode)
        {
            Type value;

            return CombinatorsMap.Constructors.TryGetValue(dataCode, out value) ? value : GetCombinatorTypeReflection(dataCode);
        }

        static Type GetCombinatorTypeReflection(uint dataCode)
        {
            if (_cachedCombinatorsLookup == null)
                _cachedCombinatorsLookup = CreateCombinatorsLookupCache();

            Type result;

            _cachedCombinatorsLookup.TryGetValue(dataCode, out result);

            return result;
        }

        public static IDictionary<uint, Type> CreateCombinatorsLookupCache()
        {
            if (_cachedTypes == null)
                _cachedTypes = CreateTypesCache();
        
            return _cachedTypes.ToDictionary(type => ((Combinator)type.GetProperty("Combinator").GetValue(null)).Name);
        }

        static IReadOnlyCollection<Type> CreateTypesCache()
        {
            var types = Assembly.GetExecutingAssembly().GetTypes();

            var enumerable = types.Where(type => typeof(TLObject).IsAssignableFrom(type));

            return enumerable.Where(type => type.GetProperties().Any(info => info.Name == "Combinator")).ToArray();
        }
    }
}