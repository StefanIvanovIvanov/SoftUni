using System;
using System.Collections.Generic;

namespace _04.Resurrection
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<decimal>phoenixes = new List<decimal>();
            for (int i = 0; i < n; i++)
            {
                long length = long.Parse(Console.ReadLine());
                decimal width = decimal.Parse(Console.ReadLine());
                long wing = long.Parse(Console.ReadLine());
                decimal totalYears = (decimal)Math.Pow(length, 2) * (width + 2 * wing);
                //Also Convert.ToDecimal(Math.Pow(length, 2));
                Console.WriteLine(totalYears);
            }
        }
    }
}