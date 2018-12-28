using System;

namespace Sunglasses
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            //upper frame
            Console.Write(new string('*', 2*n));
            Console.Write(new string(' ', n));
            Console.Write(new string('*', 2 * n));
            Console.WriteLine();

            //middle frames

            for (int row = 1; row <= n - 2; row++)
            {
                Console.Write('*');
                for (int col = 1; col <= (n * 2) - 2; col++)
                { Console.Write('/'); }
                Console.Write('*');
                for (int col = 1; col <= n; col++)
                {

                    if (row == n / 2 && n % 2 != 0)
                    { Console.Write("|"); }
                    else if (row == n / 2 - 1 && n % 2 == 0)
                    { Console.Write("|"); }
                    else
                    { Console.Write(' '); }
                }
                Console.Write('*');
                for (int col = 1; col <= (n * 2) - 2; col++)
                { Console.Write('/'); }
                Console.Write('*');
                Console.WriteLine();

            }
            //lower frames
            Console.Write(new string('*', 2 * n));
            Console.Write(new string(' ', n));
            Console.Write(new string('*', 2 * n));
            Console.WriteLine();



        }
    }
}