using System;

namespace StoppingNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int s = int.Parse(Console.ReadLine());

            for (int i = m; i >= n; i--)
            {
                if (i == s&&i % 3 == 0 && i % 2 == 0)
                { return; }
                else if (i % 3 == 0 && i % 2 == 0)
                { Console.Write(i+ " "); }
            }
        }
    }
}