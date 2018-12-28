using System;
using System.Linq;

namespace _05.LArgest3Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] num = Console.ReadLine().Split().Select(double.Parse).ToArray();
            num = num.OrderByDescending(x => x).Take(3).ToArray();
            Console.WriteLine(string.Join(" ", num));
        }
    }
}