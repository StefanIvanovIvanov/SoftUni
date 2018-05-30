using System;

namespace _03.EnglishNameOfTheLastDigit
{
    class StartUp
    {
        static void Main()
        {
            long input = long.Parse(Console.ReadLine());
            Console.WriteLine(GetLastNumber(Math.Abs(input)));
        }

        static string GetLastNumber(long number)
        {
            long lastNumber = (number % 10);
            string writeNumber = null;
            {
                if (lastNumber == 0)
                {
                    writeNumber = "zero";
                }
                else if (lastNumber == 1)
                {
                    writeNumber = "one";
                }
                else if (lastNumber == 2)
                {
                    writeNumber = "two";
                }
                else if (lastNumber == 3)
                {
                    writeNumber = "three";
                }
                else if (lastNumber == 4)
                {
                    writeNumber = "four";
                }
                else if (lastNumber == 5)
                {
                    writeNumber = "five";
                }
                else if (lastNumber == 6)
                {
                    writeNumber = "six";
                }
                else if (lastNumber == 7)
                {
                    writeNumber = "seven";
                }
                else if (lastNumber == 8)
                {
                    writeNumber = "eighth";
                }
                else if (lastNumber == 9)
                {
                    writeNumber = "nine";
                }
                return writeNumber;
            }
        }
    }
}