using System;
using System.Linq;
using System.Numerics;

namespace _01.ConvertFromBase10ToBaseN
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger[] input = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(BigInteger.Parse)
                .ToArray();

            BigInteger n = input[0];
            BigInteger number = input[1];
            BigInteger reminder = 0;
            string result = null;

            while (number > 0)
            {
                reminder = number % n;
                number = number / n;
                result = reminder.ToString()+result;
            }
            Console.WriteLine(result);

        }
    }
}