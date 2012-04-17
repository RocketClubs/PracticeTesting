using System;
using System.Collections.Generic;
using System.Linq;

namespace RocketClubs.Study.PracticeTesting
{
    internal static class IEnumerableRandomizeExtensions
    {
        internal static IEnumerable<T> Randomize<T>(this IEnumerable<T> items)
        {
            return GetRandomSubset(items, items.Count());
        }

        internal static IEnumerable<T> GetRandomSubset<T>(this IEnumerable<T> items, int numberOfItems)
        {
            var random = new Random();
            var originals = items.ToList();
            var randomSet = new List<T>();

            for (var curItem = 0; curItem < numberOfItems; curItem++)
            {
                var item = originals[random.Next(originals.Count)];
                randomSet.Add(item);
                originals.Remove(item);
            }

            return randomSet;
        }
    }
}
