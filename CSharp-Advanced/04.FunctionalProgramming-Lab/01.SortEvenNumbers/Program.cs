﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SortEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(new string[] {", "}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .Where(n => n % 2 == 0).OrderBy(n=>n).ToList();

            Console.WriteLine(string.Join(", ",numbers));
        }
    }
}
