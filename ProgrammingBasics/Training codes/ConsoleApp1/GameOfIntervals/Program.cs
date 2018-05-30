using System;

namespace GameOfIntervals
{
    class Program
    {
        static void Main(string[] args)
        {
            double n = int.Parse(Console.ReadLine());

            double result = 0;
            double part = 0;
            double zeroToNine = 0;
            double tenToNinety = 0;
            double twentyToTwentyNine = 0;
            double thirtyToThirtyNine = 0;
            double fortyToFifty = 0;
            double invalids = 0;

            for (int i = 1; i <= n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (0 <= number && number <= 9)
                {
                    part = number * 0.20;
                    zeroToNine += 1;
                    result = result+ part;
                }
                else if (10 <= number && number <= 19)
                {
                    part = number * 0.30;
                    tenToNinety += 1;
                    result = result + part;
                }
                else if (20 <= number && number <= 29)
                {
                    part = number * 0.40;
                    twentyToTwentyNine += 1;
                    result = result + part;
                }
                else if (30 <= number && number <= 39)
                {
                    thirtyToThirtyNine += 1;
                    result = result + 50;
                }
                else if (40 <= number && number <= 50)
                {
                    fortyToFifty += 1;
                    result = result + 100;
                }
                else if (50 < number || number < 0)
                {
                    invalids += 1;
                    result = result / 2;
                }
            }
            Console.WriteLine("{0:f2}", result);
            Console.WriteLine("From 0 to 9: {0:f2}%", (zeroToNine / n) * 100);
            Console.WriteLine("From 10 to 19: {0:f2}%", (tenToNinety / n) * 100);
            Console.WriteLine("From 20 to 29: {0:f2}%", (twentyToTwentyNine / n) * 100);
            Console.WriteLine("From 30 to 39: {0:f2}%", (thirtyToThirtyNine / n) * 100);
            Console.WriteLine("From 40 to 50: {0:f2}%", (fortyToFifty / n) * 100);
            Console.WriteLine("Invalid numbers: {0:f2}%", (invalids / n) * 100);

        }
    }
}