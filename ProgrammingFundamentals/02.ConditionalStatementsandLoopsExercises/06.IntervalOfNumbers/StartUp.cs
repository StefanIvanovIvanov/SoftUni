using System;

namespace _06.IntervalOfNumbers
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int smallerNumber = Math.Min(firstNumber, secondNumber);
            int largerNumber = Math.Max(firstNumber, secondNumber);
                        /*
                        for (int i = smallerNumber; i <= largerNumber; i++)
                        {
                            Console.WriteLine(i);
                        }
                        */
            while (smallerNumber <= largerNumber)
            {
                Console.WriteLine(smallerNumber);
                smallerNumber++;
            }
        }
    }
}