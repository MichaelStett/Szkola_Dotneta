namespace Roman_Calculator
{
    using static System.Console;

    class Program
    {
        static void Main(string[] args)
        {
           while (true)
            {
                Write("First arg: ");
                Calculator.LeftSide = ReadLine()?.ToUpper();

                Write($"Second arg: ");
                Calculator.RightSide = ReadLine()?.ToUpper();

                var result = Calculator.Add();

                WriteLine($"Result: {result}");

                WriteLine("====== \n");
           }
        }
    }
}
