using System;

namespace _09.RefactorSpecialNumbers
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                int number = i;
                int firstNumber = number % 10;
                number = number / 10;
                int secondNumber = number % 10;
                int sum = firstNumber + secondNumber;
                bool check = (sum == 5) || (sum == 7) || (sum == 11);
                Console.WriteLine($"{i} -> {check}");
            }

        }
    }
}