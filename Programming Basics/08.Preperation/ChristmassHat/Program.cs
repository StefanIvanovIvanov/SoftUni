using System;

namespace ChristmassHat
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int dotsLength = (2 * n) - 1;
            int dotsMiddle = 1;

            //upper part

            Console.Write(new string('.', dotsLength));
            Console.Write('/');
            Console.Write('|');
            Console.Write('\\');
            Console.Write(new string('.', dotsLength));
            Console.WriteLine();
            Console.Write(new string('.', dotsLength));
            Console.Write('\\');
            Console.Write('|');
            Console.Write('/');
            Console.Write(new string('.', dotsLength));
            Console.WriteLine();
            Console.Write(new string('.', dotsLength));
            Console.Write("***");
            Console.Write(new string('.', dotsLength));
            Console.WriteLine();

            //lower part
            int rows = dotsLength;
            for (int i = 1; i <= rows; i++)
            {
                dotsLength--;
                Console.Write(new string('.', dotsLength));
                Console.Write('*');
                Console.Write(new string('-', dotsMiddle));
                Console.Write('*');
                Console.Write(new string('-', dotsMiddle));
                Console.Write('*');
                Console.Write(new string('.', dotsLength));
                Console.WriteLine();
                dotsMiddle++;
            }
            Console.WriteLine(new string('*', 4 * n + 1));
            Console.Write('*');
            for (int j = 1; j <= (4 * n)/2; j++)
            { Console.Write(".*"); }
            Console.WriteLine();
            Console.WriteLine(new string('*', 4 * n + 1));



        }
    }
}