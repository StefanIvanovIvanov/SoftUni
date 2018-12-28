using System;

namespace _05.FibonacciNumbers
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            Console.WriteLine(Fib(input));
        }

        static int Fib(int n)
        {
            int a = 0;
            int b = 1;
            int fib = 1;
            for (int i = 1; i <= n; i++)
            {
                fib = a + b;
                a = b;
                b = fib;
            }
            return fib;     
        }
    }
}