using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpKatas
{
    public static class CollectionEx
    {
        public static void AddRange<T>(this ICollection<T> target, IEnumerable<T> source)
        {
            if (target is List<T> asList)
            {
                asList.AddRange(source);
                return;
            }

            foreach (var element in source)
            {
                target.Add(element);
            }
        }

        public static void Fill<T>(this List<T> target, int fillCount, T value)
        {
            for(int i = 0; i < fillCount; i++)
            {
                target.Add(value);
            }
        }
    }
}
