using System;

namespace _04.NumbersInReversedOrder
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Console.WriteLine(FlipNumber(input));
        }

        static string FlipNumber(string number)
        {
            string reverseNumber = null;
            for (int i = number.Length-1; i >= 0; i--)
            {
                reverseNumber = reverseNumber + number[i];
            }
            return reverseNumber;
        }
    }
}