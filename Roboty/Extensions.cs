using System;
using System.Collections.Generic;
using System.Linq;

namespace Roboty
{
    public static class Extensions
    {
        public static string GetRandom(this string text, int count)
        {
            var random = new Random();

            return new string(Enumerable.Repeat(text, count).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static List<T> Replace<T>(this List<T> enumerable, T obj1, T obj2)
        {
            enumerable[enumerable.IndexOf(obj1)] = obj2;

            return enumerable;
        }
    }
}
