﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roman_Calculator
{
    // https://www.geeksforgeeks.org/converting-roman-numerals-decimal-lying-1-3999/

    public static class Calculator
    {
        public static string? LeftSide = null;
        public static string? RightSide = null;

        static Dictionary<string, int> romanNumbers = new Dictionary<string, int>()
           {
               {"I",    1},
               {"V",    5},
               {"X",   10},
               {"L",   50},
               {"C",  100},
               {"D",  500},
               {"M", 1000}
           };

        public static int Add()
        {
            if (LeftSide is null || RightSide is null)
            {
                throw new NullReferenceException();
            }

            var left = Evaluate(LeftSide);
            var right = Evaluate(RightSide);

            LeftSide = null;
            RightSide = null;

            return left + right;
        }

        public static int Evaluate(string numbers)
        {
            var previous = 0;
            var answer = 0;

            foreach (var num in numbers.Reverse()) // from back
            {
                var current = romanNumbers[$"{num}"];

                //Console.WriteLine(current);

                if (current >= previous)
                {
                    answer += current;
                }
                else
                {
                    answer -= current;
                }

                previous = current;
            }

            return answer;
        }

        public static string ArabicToRoman(int number)
            => number switch
            {
                1 => "I",
                4 => "IV",
                5 => "V",
                9 => "IX",
                10 => "X",
                40 => "XL",
                50 => "L",
                90 => "XC",
                100 => "C",
                400 => "CD",
                500 => "D",
                900 => "CM",
                1000 => "M",
                _ => string.Empty
            };

        public static int RomanToArabic(string number)
            => number switch
            {
                "I" => 1,
                "IV" => 4,
                "V" => 5,
                "IX" => 9,
                "X" => 10,
                "XL" => 40,
                "L" => 50,
                "XC" => 90,
                "C" => 100,
                "CD" => 400,
                "D" => 500,
                "CM" => 900,
                "M" => 1000,
                _ => 0
            };
    }
}
