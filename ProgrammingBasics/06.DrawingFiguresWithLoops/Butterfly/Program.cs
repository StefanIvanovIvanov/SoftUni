using System;

namespace Butterfly
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var width = 2 * n - 1;
            var heigth = 2 * (n - 2) + 1;

            var halfHeight = heigth / 2;

            var symbolsSide = width / 2 - 1;

            var stars = new string('*', symbolsSide);
            var dashes = new string('-', symbolsSide);
            var spaces = new string(' ', symbolsSide+1);

            for (int row = 1; row <= halfHeight; row++)
            {
                if (row % 2 != 0)
                {
                    Console.Write(stars);
                    Console.Write('\\');
                    Console.Write(' ');
                    Console.Write('/');
                    Console.Write(stars);
                    Console.WriteLine();
                }
                else if (row % 2 == 0)
                {
                    Console.Write(dashes);
                    Console.Write('\\');
                    Console.Write(' ');
                    Console.Write('/');
                    Console.Write(dashes);
                    Console.WriteLine();
                }
            }
            Console.Write(spaces);
            Console.Write('@');
            Console.Write(spaces);
            Console.WriteLine();
            for (int row = 1; row <= halfHeight; row++)
            {
                if (row % 2 != 0)
                {
                    Console.Write(stars);
                    Console.Write('/');
                    Console.Write(' ');
                    Console.Write('\\');
                    Console.Write(stars);
                    Console.WriteLine();
                }
                else if (row % 2 == 0)
                {
                    Console.Write(dashes);
                    Console.Write('/');
                    Console.Write(' ');
                    Console.Write('\\');
                    Console.Write(dashes);
                    Console.WriteLine();
                }
            }
        }
    }
}