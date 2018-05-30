using System;
using System.Collections.Generic;
using System.Linq;

namespace _6.SquareNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).OrderByDescending(a => a).ToList();

            List<int> square = new List<int>();

            foreach (int number in input)
            {
                if (Math.Sqrt(number) == (int) Math.Sqrt(number))
                {
                    square.Add(number);
                }
            }
            Console.WriteLine(string.Join(" ", square));
        }
    }
}