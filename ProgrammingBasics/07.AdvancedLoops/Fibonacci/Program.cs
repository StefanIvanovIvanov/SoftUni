using System;

namespace Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int f0 = 1;
            int f1 = 1;
            int result = 0;
            for (int i = 1; i<= n - 1; i++)
            {

                result = f0 + f1;
                f0 = f1;
                f1 = result;

            }
            Console.WriteLine(f1);

        }
    }
}