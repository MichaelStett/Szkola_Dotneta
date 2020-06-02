using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using static System.Console;
using static System.Environment;

namespace AlphanumericInFile
{
    public static class IntExtension
    {
        public static char ToChar(this int i) => (char)i;
    }

    public static class CharExtension
    {
        static Regex letterUpercaseRegex = new Regex("[A-Z]");
        static Regex letterLowercaseRegex = new Regex("[a-z]");
        static Regex numberRegex = new Regex("[0-9]");

        public static bool IsLetterLowercase(this char c) => letterLowercaseRegex.IsMatch(c.ToString());
        public static bool IsLetterUpercase(this char c) => letterUpercaseRegex.IsMatch(c.ToString());
        public static bool IsNumber(this char c) => numberRegex.IsMatch(c.ToString());
    }

    public class Program
    {
        public static Dictionary<int, int> Count = new Dictionary<int, int>();

        static Program()
        {
            SetIn(new StreamReader(OpenStandardInput()));

            Enumerable.Range('a', 26).ToList().ForEach(letter => Count.Add(letter, 0));
            Enumerable.Range(0, 10).ToList().ForEach(number => Count.Add(number, 0));
        }

        static void Main(string[] args)
        {
            var lines = new List<string>(In.ReadToEnd().Split(separator: NewLine)).ConvertAll(l => l.ToLower());

            foreach (var line in lines)
            {
                foreach (var symbol in line)
                {
                    if (symbol.IsLetterLowercase())
                    {
                        Count[symbol] += 1;
                    }
                    else if (symbol.IsNumber())
                    {
                        Count[symbol - 48] += 1;
                    }
                }
            }

            foreach (var item in Count.OrderByDescending(item => item.Value).Take(10))
            {
                if (item.Key.ToChar().IsLetterLowercase())
                {
                    WriteLine($"{item.Key.ToChar()}: {item.Value}");
                }
                else
                {
                    WriteLine($"{item.Key}: {item.Value}");
                }
            }
        }
    }
}
