using System;

namespace Christmas_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Console.Write(new string(' ', n + 1));
            Console.WriteLine('|');
            for (int row = 1; row <= n; row++)
            {
                for (int col = 1; col <= n - row; col++)
                { Console.Write(' '); }
                for (int col = 1; col <= row; col++)
                { Console.Write("*"); }
                Console.Write(" | ");
                for (int col = 1; col <= row; col++)
                { Console.Write("*"); }
                for (int col = 1; col <= n - row; col++)
                { Console.Write(' '); }
                Console.WriteLine();
            }
            
        }
    }
}