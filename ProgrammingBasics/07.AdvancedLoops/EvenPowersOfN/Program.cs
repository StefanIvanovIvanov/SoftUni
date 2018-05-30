using System;

namespace EvenPowersOfN
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

                int num = 1;
            for (int i = 1; i <= n+1; i+=2)
            {
                Console.WriteLine(num);
                num = num * 4;
            }
        }
    }
}