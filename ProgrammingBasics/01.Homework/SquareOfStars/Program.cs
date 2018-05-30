using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareOfStars
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
                if (i == 1 || i == n)
                {
                    Console.WriteLine(new string('*', n));
                }
                else
                {
                    Console.WriteLine('*' + new string(' ', n - 2) + '*');
                }
        }
    }
}
