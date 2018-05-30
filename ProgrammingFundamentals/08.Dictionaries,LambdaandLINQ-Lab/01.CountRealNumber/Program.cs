using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Linq;

namespace _01.CountRealNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split(' ');

            var count = new SortedDictionary<double, int>();

            foreach (var number in numbers)
            {
                double parsed = double.Parse(number);
                if (count.ContainsKey(parsed))
                {
                    count[parsed]++;
                }
                else
                {
                    count[parsed] = 1;
                }
            }
            foreach (var num in count.Keys)
            {
                Console.WriteLine("{0} -> {1}", num, count[num]);

            }
        }
    }
}