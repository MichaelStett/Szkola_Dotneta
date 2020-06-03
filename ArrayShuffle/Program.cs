using System.IO;
using System.Linq;
using System.Collections.Generic;

using static System.Console;
using static Newtonsoft.Json.JsonConvert;

namespace ArrayShuffle
{
    public class NumbersLetters
    {
        public List<int> Numbers { get; set; } = new List<int>();
        public List<string> Letters { get; set; } = new List<string>();
    }

    class Program
    {
        static void Main(string[] args)
        {
            using var reader = new StreamReader("data.json");

            var json = reader.ReadToEnd();

            var numbersLetters = DeserializeObject<NumbersLetters>(json);

            var numbers = numbersLetters.Numbers;
            var letters = numbersLetters.Letters;

            var merged = Enumerable.Zip(letters, numbers, (l, n) => (Letter: l, Number: n.ToString()));

            var result = new List<string>();

            foreach (var (Letter, Number) in merged)
            {
                if (Letter is not null)
                {
                    result.Add(Letter);
                }

                if (Number is not null)
                {
                    result.Add(Number);
                }
            }

            foreach(var item in result)
            {
                Write($"{item} ");
            }
        }
    }
}
