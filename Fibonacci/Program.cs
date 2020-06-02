using static System.Console;
using static System.Math;
using static System.Convert;
using static System.Linq.Enumerable;

namespace Fibonacci
{
    public class Program
    {
        // http://www.maths.surrey.ac.uk/hosted-sites/R.Knott/Fibonacci/fibFormula.html
       
        public static double Phi = (Sqrt(5) + 1) / 2;
        public static double negativePhi = (1 - Sqrt(5)) / 2;

        private static int Fibonacci(int n)
            => n switch
            {
                0 => 0,
                1 => 1,
                _ => ToInt32((Pow(Phi, n) - Pow(negativePhi, n)) / Sqrt(5))
            };

        static void Main(string[] args)
        {
            var n = 6;
            WriteLine(n);

            foreach (var number in Range(0, n)) // <0, n)
            {
               Write($"{Fibonacci(number)} ");
            }
        }
    }
}
