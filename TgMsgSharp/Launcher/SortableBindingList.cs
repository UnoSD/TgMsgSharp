using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace TgMsgSharp.Launcher
{
    public class SortableBindingList<T> : BindingList<T>
    {
        bool _isSortedValue;
        ListSortDirection _sortDirectionValue;
        PropertyDescriptor _sortPropertyValue;

        public SortableBindingList(IEnumerable<T> list)
        {
            foreach (var item in list)
                this.Add(item);
        }

        protected override bool SupportsSearchingCore => true;

        protected override int FindCore(PropertyDescriptor prop, object key)
        {
            var propInfo = typeof(T).GetProperty(prop.Name);

            if (key == null) return -1;

            for (var i = 0; i < Count; ++i)
            {
                var item = Items[i];
                if (propInfo.GetValue(item, null).Equals(key))
                    return i;
            }

            return -1;
        }

        protected override bool SupportsSortingCore => true;
        
        protected override bool IsSortedCore => _isSortedValue;

        protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
        {
            var interfaceType = prop.PropertyType.GetInterface("IComparable");

            if (interfaceType == null && prop.PropertyType.IsValueType)
            {
                var underlyingType = Nullable.GetUnderlyingType(prop.PropertyType);

                if (underlyingType != null)
                {
                    interfaceType = underlyingType.GetInterface("IComparable");
                }
            }

            if (interfaceType != null)
            {
                _sortPropertyValue = prop;
                _sortDirectionValue = direction;

                IEnumerable<T> query = base.Items;

                query = direction == ListSortDirection.Ascending ? query.OrderBy(i => prop.GetValue(i)) : query.OrderByDescending(i => prop.GetValue(i));

                var newIndex = 0;

                foreach (object item in query)
                {
                    this.Items[newIndex] = (T) item;
                    newIndex++;
                }

                _isSortedValue = true;

                this.OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
            }
            else
                throw new NotSupportedException($"Cannot sort by {prop.Name}. This{prop.PropertyType} does not implement IComparable");
        }
        
        protected override PropertyDescriptor SortPropertyCore => _sortPropertyValue;

        protected override ListSortDirection SortDirectionCore => _sortDirectionValue;
    }
}