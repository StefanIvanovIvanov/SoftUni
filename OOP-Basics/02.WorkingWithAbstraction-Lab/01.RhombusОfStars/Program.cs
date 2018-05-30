using System;

namespace _01.RhombusОfStars
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i < n; i++)
            {
                PrintRhombus(n, i);
            }
            for (int i = n; i >= 0; i--)
            {
                PrintRhombus(n, i);
            }
        }

        static void PrintRhombus(int rhombusSize, int rowSize)
        {
            for (int i = 0; i < (rhombusSize - rowSize); i++)
            {
                Console.Write(" ");
            }
            for (int i = 0; i < rowSize; i++)
            {
                Console.Write("* ");
            }
            Console.WriteLine();
        }
    }
}
