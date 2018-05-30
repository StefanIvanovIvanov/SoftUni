using System;

namespace SumDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int sumOfDigits = 0;


            do
            {
                int lastNumber = n % 10;
                n = n / 10;
                sumOfDigits = sumOfDigits + lastNumber;
            } while (n > 0);
            Console.WriteLine(sumOfDigits);
        }
    }
}