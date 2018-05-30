using System;
using System.Linq;

namespace _10.PairsByDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = Console.ReadLine().Split().Select(int.Parse).ToList();
            var diff = int.Parse(Console.ReadLine());
            var count = 0;

            foreach (var num in list)
            {
                foreach (var nums in list)
                {
                    if (num - nums == diff)
                    {
                        count++;
                    }
                }
            }
            Console.WriteLine(count);
        }
    }
}