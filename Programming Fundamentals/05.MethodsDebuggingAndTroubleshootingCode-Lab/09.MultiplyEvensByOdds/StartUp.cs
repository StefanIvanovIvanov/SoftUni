using System;

namespace _09.MultiplyEvensByOdds
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int input = Math.Abs(int.Parse(Console.ReadLine()));
            int resultEven = EvenDigits(input);
            int resultOdd = OddDigits(input);
            Console.WriteLine(resultEven * resultOdd);
        }

        static int EvenDigits(int number)
        {
            int sum = 0;
            while (number > 0)
            {
                int lastNumber = number % 10;
                if (lastNumber % 2 == 0)
                {
                    sum = sum + lastNumber;
                }
                number = number / 10;
            }
            return sum;
        }

        static int OddDigits(int number)
        {
            int sum = 0;
            while (number > 0)
            {
                int lastNumber = number % 10;
                if (lastNumber % 2 != 0)
                {
                    sum = sum + lastNumber;
                }
                number = number / 10;
            }
            return sum;
        }
    }
}