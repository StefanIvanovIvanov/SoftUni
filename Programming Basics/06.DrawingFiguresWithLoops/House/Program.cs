using System;

namespace House
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int stars = 1;
            if (n % 2 == 0)
                stars = 2;
            int dashes = n - stars;

            for (int row = 1; row <= (n+1)/2; row++)
            {
                Console.Write(new string('-', dashes/2));
                Console.Write(new string('*', stars));
                Console.Write(new string('-', dashes / 2));
                Console.WriteLine();
                stars+=2;
                dashes-=2;
            }
            for (int row = 1; row <= n / 2; row++)
            {
                Console.Write("|");
                Console.Write(new string('*', n-2));
                Console.Write("|");
                Console.WriteLine();
            }
        }
    }
}