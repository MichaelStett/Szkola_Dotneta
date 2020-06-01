using System;
using System.Collections.Generic;
using System.Linq;

using static System.Console;
using static System.Environment;

namespace IntsMerge
{
    public class Program
    {
        // https://stackoverflow.com/questions/1952153/what-is-the-best-way-to-find-all-combinations-of-items-in-an-array answer of Pengyang May 17 '12
        static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> list, int length)
        {
            if (length == 1) 
                return list.Select(t => new T[] { t });
            
            return GetPermutations(list, length - 1)
                .SelectMany(t => list.Where(e => !t.Contains(e)),
                            (t1, t2) => t1.Concat(new T[] { t2 }));
        }


        static void Main(string[] args)
        {
            if (args.Length == 0 || args.Length == 1)
            {
                WriteLine("Please enter at least two arguments.");
                Exit(-1);
            }

            var input = args.Select(arg => int.Parse(arg));

            if (input.Min() < 0)
            {
                WriteLine("Please enter only positive arguments.");
                Exit(-1);
            }

            var length = input.Count();

            var inputPermutated = GetPermutations(input, length);

            var numbers = new List<int>();

            foreach (var item in inputPermutated)
            {
                if (int.TryParse(string.Join("", item), out var number))
                    numbers.Add(number);
            }

            if (numbers.Any())
            {
                var max = numbers.Max();
                var min = numbers.Min();

                WriteLine($"Min: {min}");
                WriteLine($"Max: {max}");
            }
            else
            {
                WriteLine("Arguments concatenated exceeds Int32.MaxValue");
            }
        }
    }
}
