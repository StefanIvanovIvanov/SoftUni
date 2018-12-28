using System;

namespace Keep
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            
            int arrows = n / 2;
            int underlines = n - 2 - arrows;
            int spaces = 2 + 2 * arrows + 2 * underlines;

            Console.Write('/');
            Console.Write(new string('^', arrows));
            Console.Write('\\');
            Console.Write(new string('_', underlines));
            Console.Write(new string('_', underlines));
            Console.Write('/');
            Console.Write(new string('^', arrows));
            Console.Write('\\');
            Console.WriteLine();

            for (int row = 1; row <= n - 3; row++)
            {
                Console.Write('|');
                Console.Write(new string (' ', spaces));
                Console.Write('|');
                Console.WriteLine();
            }
            Console.Write('|');
            Console.Write(new string(' ', arrows+1));
            Console.Write(new string('_', underlines));
            Console.Write(new string('_', underlines));
            Console.Write(new string(' ', arrows+1));
            Console.Write('|');
            Console.WriteLine();


            Console.Write('\\');
            Console.Write(new string('_', arrows));
            Console.Write('/');
            Console.Write(new string(' ', underlines*2));
            Console.Write('\\');
            Console.Write(new string('_', arrows));
            Console.Write('/');
            Console.WriteLine();

        }
    }
}