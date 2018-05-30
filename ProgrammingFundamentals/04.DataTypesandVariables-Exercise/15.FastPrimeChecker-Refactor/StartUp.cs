using System;

namespace _15.FastPrimeChecker_Refactor
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int lastNumber = int.Parse(Console.ReadLine());

            for (int number = 2; number <= lastNumber; number++)
            {
                bool isPrime = true;
                for (int two = 2; two <= Math.Sqrt(number); two++)
                {
                    if (number % two == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                Console.WriteLine($"{number} -> {isPrime}");
            }

        }
    }
}