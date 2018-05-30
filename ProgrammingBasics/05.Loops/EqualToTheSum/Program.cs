using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EqualToTheSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var max = 0;
            var sum = 0;
            for (int i = 1; i <= n; i++)
            {
                var number = int.Parse(Console.ReadLine());
                if (max<number)
            { max = number; }
                sum = sum + number;
            }
            var sumMinuxMax = sum - max;

            var diff = Math.Abs(sumMinuxMax - max);
            if (sumMinuxMax == max)
            { Console.WriteLine("Yes Sum = " + max); }
            else if (sumMinuxMax != max) { Console.WriteLine("No Diff = " + diff); }
        }
    }
}
