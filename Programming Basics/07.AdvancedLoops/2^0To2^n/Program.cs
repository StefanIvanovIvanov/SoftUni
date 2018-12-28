using System;

namespace _2_0To2_n
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int num = 1;

            for (int i = 1; i <= n+1; i++)
            {
                Console.WriteLine(num);
                num = num * 2;
            }
        }
    }
}