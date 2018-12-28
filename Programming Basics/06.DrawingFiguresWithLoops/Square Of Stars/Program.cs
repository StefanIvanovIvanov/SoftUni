using System;

namespace Square_Of_Stars
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());


            for (int row = 1; row <= n; row++)
            {
                Console.Write('*');
                for (int col = 1; col <= n-1; col++)
                { Console.Write(" *"); }
                Console.WriteLine();
            }
            
        }
    }
}