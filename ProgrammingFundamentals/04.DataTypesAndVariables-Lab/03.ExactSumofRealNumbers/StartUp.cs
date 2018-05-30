using System;

namespace _03.ExactSumofRealNumbers
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            decimal sum = 0;

            for (int i = 1; i <= n; i++)
            {
                decimal input = decimal.Parse(Console.ReadLine());
                sum = sum + input;
            }
            Console.WriteLine(sum);
        }
    }
}