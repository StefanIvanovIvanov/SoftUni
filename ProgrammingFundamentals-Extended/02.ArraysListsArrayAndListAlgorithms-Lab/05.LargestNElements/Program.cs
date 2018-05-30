using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.LargestNElements
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            int n = int.Parse(Console.ReadLine());
            List<int> result = new List<int>();

            numbers.Sort();

            for (int i = numbers.Count-1; i >=numbers.Count-n; i--)
            {
                result.Add(numbers[i]);
            }
            Console.WriteLine(string.Join(" ",result));
        }
    }
}