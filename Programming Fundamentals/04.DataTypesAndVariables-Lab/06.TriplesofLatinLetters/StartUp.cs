using System;

namespace _06.TriplesofLatinLetters
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i <= n-1; i++)
            {
                for (int j = 0; j <= n-1; j++)
                {
                    for (int k = 0; k <= n-1; k++)
                    {
                        char first = (char)('a' + i);
                        char second = (char)('a' + j);
                        char third = (char)('a' + k);

                        Console.WriteLine($"{first}{second}{third}");
                    }
                }
            }
        }
    }
}