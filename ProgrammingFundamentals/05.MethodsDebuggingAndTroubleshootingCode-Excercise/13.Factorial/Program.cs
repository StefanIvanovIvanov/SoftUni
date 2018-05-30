using System;
using System.Numerics;

namespace _13.Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(GetFactorial(n));
        }

        static BigInteger GetFactorial(BigInteger number)
        {
            BigInteger result = 1;
            do
            {
                result = result * number;
                number--;
            } while (number > 0);
            return result;
        }
    }
}