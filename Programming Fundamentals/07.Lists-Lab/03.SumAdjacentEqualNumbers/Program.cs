using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace _03.SumAdjacentEqualNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> input = Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse).ToList();

            int sum=0;
            for (int i = 1; i < input.Count; i++)
            {
                if (input[i-1] == input[i])
                {
                    input[i] = input[i] + input[i - 1];
                    input.Remove(input[i-1]);
                    i = 0;
                }
            }
            Console.WriteLine(string.Join(" ", input));
        }

    }
}