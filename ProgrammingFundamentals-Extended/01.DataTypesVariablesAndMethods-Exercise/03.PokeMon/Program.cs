using System;
using System.Diagnostics.Tracing;

namespace _03.PokeMon
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());
            int halfN = n / 2;
            int count = 0;

            while (n >= m)
            {
                n = n - m;
                if (n == halfN && y != 0)
                {
                    n = n / y;
                }
                count++;
            }
            Console.WriteLine(n);
            Console.WriteLine(count);
        }
    }
}