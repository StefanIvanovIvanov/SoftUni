using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.SortNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<decimal> numbers = Console.ReadLine().Split().Select(decimal.Parse).ToList();
            numbers.Sort();

            Console.WriteLine(string.Join(" <= ", numbers));
        }
    }
}