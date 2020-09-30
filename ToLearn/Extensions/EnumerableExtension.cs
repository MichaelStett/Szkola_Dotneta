using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToLearn.Extensions
{
    public static class EnumerableExtension
    {
        public static IEnumerable<(T value, int index)> WithIndex<T>(this IEnumerable<T> self)
            => self.Select((value, index) => (value, index));

        public static void WriteInLines<T>(this IEnumerable<T> self)
            => self.ToList().ForEach(x => Console.WriteLine($"{x}"));
    }
}
