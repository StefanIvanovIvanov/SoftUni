using System;

namespace _06.PrimeChecker
{
    class StartUp
    {
        static void Main(string[] args)
        {
            double n = double.Parse(Console.ReadLine());

            Console.WriteLine(IsPrime(n));
        }

        static bool IsPrime(double number)
        {
            if (number > 1)
            {
                for (int i = 2; i <= Math.Sqrt(number); i++)
                {
                    if (number % i == 0)
                        return false;
                }
            }
            else
            {
                return false;
            }
            return true;
        }
    }
}