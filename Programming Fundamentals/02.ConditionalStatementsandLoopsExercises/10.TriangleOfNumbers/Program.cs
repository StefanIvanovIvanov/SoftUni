using System;

namespace _10.TriangleOfNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int number = 1;

            for (int col = 1; col <= n; col++)
            {
                for (int row = 1; row <= col; row++)
                {
                    Console.Write(number + " ");
                }
                number++;
                Console.WriteLine();              
            }

        }
    }
}