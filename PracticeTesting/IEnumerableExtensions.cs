using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PracticeTesting
{
    internal static class IEnumerableRandomizeExtensions
    {
        internal static IEnumerable<T> Randomize<T>(this IEnumerable<T> items)
        {
            return GetRandomSubset(items, items.Count());
        }

        internal static IEnumerable<T> GetRandomSubset<T>(this IEnumerable<T> items, int numberOfItems)
        {
            Random random = new Random();
            List<T> originals = items.ToList();
            List<T> randomSet = new List<T>();

            for (int curItem = 0; curItem < numberOfItems; curItem++)
            {
                T item = originals[random.Next(originals.Count)];
                randomSet.Add(item);
                originals.Remove(item);
            }

            return randomSet;
        }

        internal static IEnumerable<T> Clone<T>(this IList<T> listToClone) where T : ICloneable
        {
            return listToClone.Select(item => (T)item.Clone()).ToList();
        }
    }
}
