using System;

using static System.Console;

namespace Triangles_Squares
{
    class Program
    {
        static char symbol = '*';
        static char space = ' ';
        static string sep = "\n";

        static void Draw_Square(int width)
        {
            for (int i = 0; i <= width; i++)
            {
                for (int j = 0; j <= width; j++)
                {
                    if ((i == 0 || j == 0) || (i == width || j == width))
                    {
                        Write(symbol);
                    }
                    else
                    {
                        Write(space);
                    }
                }
                Write(sep);
            }
        }

        static void Draw_SimpleTriangle(int width)
        {
            for (int i = 0; i <= width; i++)
            {
                for (int j = 0; j <= width; j++)
                {
                    if ((j == 0) || (i == j) || (i == width))
                    {
                        Write(symbol);
                    }
                    else
                    {
                        Write(space);
                    }
                }
                Write(sep);
            }
        }
        static void Draw_IsoscelesTriangle(int width)
        {
            for (int i = 1; i < width; i++)
            {
                for (int j = width - i; j > 0; j--)
                {
                    Write(space);
                }
                for (int j = 2*i - 1; j > 0; j--)
                {
                    Write(symbol);
                }
                for (int j = width - i; j > 0; j--)
                {
                    Write(space);
                }
                Write(sep);
            }
        }


        static void Main(string[] args)
        {
            var width = 5;

            Draw_Square(width);
            WriteLine();

            Draw_SimpleTriangle(width);
            WriteLine();

            Draw_IsoscelesTriangle(width);
            WriteLine();

        }
    }
}
