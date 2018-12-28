using System;

namespace Rhombus
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int spaces = n - 1;
            int stars = 1;

            for (int row = 1; row <= n; row++)
            {
                for (int col = 1; col <= spaces; col++)
                {
                    Console.Write(" ");
                }
                Console.Write("*");
                for (int col = 1; col <= stars-1; col++)
                {
                    Console.Write(" *");
                }
                Console.WriteLine();
                spaces--;
                stars++;
            }
          stars = stars - 2;
            spaces = spaces + 2;
            for (int row = 1; row <= n-1; row++)
            {
                for (int col = 1; col <= spaces; col++)
                {
                    Console.Write(" ");
                }
                Console.Write("*");
                for (int col = 1; col <= stars-1; col++)
                {
                    Console.Write(" *");
                }
                Console.WriteLine();
                spaces++;
                stars--;
            }
        }
    }
}