using System;
using System.Linq;
using System.Numerics;
using System.Text;

namespace _02.ConvertFromBaseNtoBase10
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            long n = long.Parse(input[0]);
            string number = input[1];
            BigInteger result = 0;
            int power = number.Length - 1;

            for (int i = 0; i < number.Length; i++)
            {
                BigInteger num = BigInteger.Parse(number[i].ToString());
                result  = result+ BigInteger.Multiply(num, BigInteger.Pow(n, power));
                power--;
            }
            Console.WriteLine(result);
        }
    }
}