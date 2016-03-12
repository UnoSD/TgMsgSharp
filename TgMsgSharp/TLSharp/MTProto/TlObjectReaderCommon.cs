using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace TLSharp.Core.MTProto
{
    public class TlObjectReaderCommon : ITlObjectReader
    {
        static readonly IDictionary<Type, Func<BinaryReader, object>> _readFunctions;

        static TlObjectReaderCommon()
        {
            _readFunctions = new Dictionary<Type, Func<BinaryReader, object>>
            {
                [typeof(int)] = reader => reader.ReadInt32(),
                [typeof(string)] = reader => Serializers.String.read(reader),
                [typeof(Peer)] = reader => TL.Parse<Peer>(reader),
                [typeof(MessageMedia)] = reader => TL.Parse<MessageMedia>(reader)
        };
        }

        public T Read<T>(BinaryReader reader, Type typeToCreate)// where T : new()
        {
            var instance = (T)Activator.CreateInstance(typeToCreate);

            var properties = typeToCreate.GetProperties().Where(IsTlProperty).OrderBy(GetPropertyOrder);

            foreach (var propertyInfo in properties)
            {
                var readFunction = GetReadFunction(propertyInfo.PropertyType);

                var value = readFunction(reader);

                propertyInfo.SetValue(instance, value);
            }

            return instance;
        }

        // Is reflection cached? If not, it might be better not to use LINQ and avoiding GetCustomAttributes twice.
        static bool IsTlProperty(PropertyInfo propertyInfo) => propertyInfo.GetCustomAttributes().OfType<TlPropertyAttribute>().Any();

        static Func<BinaryReader, object> GetReadFunction(Type type)
        {
            Func<BinaryReader, object> function;

            _readFunctions.TryGetValue(type, out function);

            if(function == null)
                throw new NotImplementedException();

            return function;
        }

        static int GetPropertyOrder(PropertyInfo propertyInfo)
        {
            var orderAttribute = propertyInfo.GetCustomAttribute<TlPropertyAttribute>();

            return orderAttribute.Order;
        }
    }
}