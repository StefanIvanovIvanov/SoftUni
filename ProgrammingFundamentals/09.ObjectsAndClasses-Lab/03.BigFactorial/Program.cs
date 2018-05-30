using System;
using System.Numerics;

namespace _03.BigFactorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            BigInteger factorial = 1;

            while (n > 0)
            {
                factorial = factorial * n;
                n--;
            }
            Console.WriteLine(factorial);
        }
    }
}