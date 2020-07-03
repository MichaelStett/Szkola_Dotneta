using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

using static System.Console;
using static System.Linq.Enumerable;

namespace LookAndRead
{
    public static class Extension
    {
        // https://stackoverflow.com/questions/271398/what-are-your-favorite-extension-methods-for-c-codeplex-com-extensionoverflow/274649#274649
        public static void ForEach<T>(this IEnumerable<T> @enum, Action<T> mapFunction)
        {
            foreach (var item in @enum) mapFunction(item);
        }

        public static IEnumerable<string> SplitNumbers(this string s)
        {
            var sb = new StringBuilder();

            var arr = s.Select(c => c.ToString());

            var prev = arr.First();

            sb.Append(prev);

            foreach (var letter in arr.Skip(1))
            {
                if (!letter.Equals(prev))
                {
                    yield return sb.ToString();

                    sb.Clear();
                }

                sb.Append(letter);
                prev = letter;
            }

            yield return sb.ToString();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var sb = new StringBuilder();

            var text = "1";

            WriteLine(text);

            if (uint.TryParse(args[0], out var N))
            {
                Range(0, (int)N).ForEach(_ =>
                {
                    text.SplitNumbers().ForEach(s => sb.Append($"{s.Length}{s.First()}"));

                    WriteLine(text = sb.ToString());

                    sb.Clear();
                });
            }
        }
    }
}
