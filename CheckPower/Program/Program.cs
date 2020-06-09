using System;
using System.Collections.Generic;
using System.Linq;

using static System.Math;
using static System.Convert;
using static System.Console;

namespace CheckPower
{
    public static class IEnumerableExtension
    {
        public static bool IsSquareOf(this IEnumerable<int> squares, IEnumerable<int> numbers)
        {
            var numbersSquared = numbers.Select(n => n*n).ToList();

            return Enumerable.SequenceEqual(numbersSquared, squares);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new List<int> { 1, 2, 3, 4, 5 };
            var squares = new List<int> { 1, 4, 9, 16, 25 };
            
            var IsEqual = squares.IsSquareOf(numbers);

            WriteLine($"{IsEqual}");
        }
    }
}
