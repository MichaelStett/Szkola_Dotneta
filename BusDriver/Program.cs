using System;
using System.Collections.Generic;
using System.Linq;

using static System.Console;

namespace BusDriver
{
    class Program
    {
        static int GCD(int a, int b)
        {
            if (a == 0)
                return b;

            return GCD(b % a, a);
        }

        static int LCM(int a, int b)
        {
            return (a * b) / GCD(a, b);
        }

        public static int IndexOfFirstCommon(List<int> x, List<int> y)
        {
            for (var i = 0; i < x.Count; i++)
            {
                if (x[i] == y[i])
                {
                    return i;
                }
            }

            return -1;
        }

        static void Main(string[] args)
        {
            var drivers = new List<List<int>>
            {
               new List<int> { 3, 1, 2, 3 },
               new List<int> { 3, 2, 3, 1 },
               new List<int> { 4, 2, 3, 4, 5 },
            };

            //var drivers = new List<List<int>>
            //{
            //    new List<int>{ 2, 1, 2 },
            //    new List<int>{ 5, 2, 8 },
            //};

            var results = new List<int>();

            do
            {
                var d0 = drivers.ElementAt(0);

                for (int i = 1; i < drivers.Count; i++)
                {
                    var d1 = drivers.ElementAt(i);

                    var lcm = LCM(d0.Count, d1.Count);

                    var x = Enumerable.Repeat(d0, lcm / d0.Count).SelectMany(x => x).ToList();
                    var y = Enumerable.Repeat(d1, lcm / d1.Count).SelectMany(x => x).ToList();

                    //x.ForEach(i => Write($"{i} ")); WriteLine();
                    //y.ForEach(i => Write($"{i} ")); WriteLine();

                    var index = IndexOfFirstCommon(x, y);

                    results.Add(index);
                }

                drivers.RemoveAt(0);

            } while (drivers.Count - 1 > 0);

            var r = results.Max() - 1;
            WriteLine(r > 0 ? r.ToString() : "NIGDY");
        }
    }
}
