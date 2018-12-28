using System;
using System.Numerics;

namespace _03.BigPower
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            BigInteger result = BigInteger.Pow(n, n);
            Console.WriteLine(result);
        }
    }
}