using System;

namespace _12.TestNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int stop = int.Parse(Console.ReadLine());

            int combNumber = 0;
            int sum = 0;
            int number = 0;


            for (int i = n; i >= 1; i--)
            {
                for (int j = 1; j <= m; j++)
                {
                    if (sum < stop)
                    {
                        number = 3 * (i * j);
                        sum = sum + number;
                        combNumber++;
                    }
                }
            }
            if (sum >= stop)
            {
                Console.WriteLine($"{combNumber} combinations");
                Console.WriteLine($"Sum: {sum} >= {stop}");
            }
            else if (sum < stop)
            {
                Console.WriteLine($"{combNumber} combinations");
                Console.WriteLine($"Sum: {sum}");
            }
        }
    }
}