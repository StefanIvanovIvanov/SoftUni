using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.RecursiveFibonacci
{
    class Program
    {
        private static long[] reminder;

        public static void Main()
        {
            var n = long.Parse(Console.ReadLine());
            reminder = new long[n + 1];
            Console.WriteLine(getFibonacci(n));
        }

        private static long getFibonacci(long n)
        {
            if (n <= 2)
            {
                return 1;
            }

            if (reminder[n] == 0)
            {
                reminder[n] = getFibonacci(n - 1) + getFibonacci(n - 2);
            }

            return reminder[n];
        }
    }
}
