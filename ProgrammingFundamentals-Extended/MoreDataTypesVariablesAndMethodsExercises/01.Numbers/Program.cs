using System;
using System.Linq;

namespace _01.Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            double average = input.Average();

            int[] results = input.OrderByDescending(x=>x).Where(x => x > average).Take(5).ToArray();

            if (results.Length != 0)
            {
                Console.WriteLine(String.Join(" ", results));
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}