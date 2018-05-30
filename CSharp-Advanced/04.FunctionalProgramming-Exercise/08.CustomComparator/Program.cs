using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.CustomComparator
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            var evenNums = numbers.FindAll(delegate (int num)
            {
                return num % 2 == 0;
            });

            evenNums.Sort();

            var oddNums = numbers.FindAll(delegate (int num)
            {
                return num % 2 != 0;
            });

            oddNums.Sort();

            var result = evenNums.Concat(oddNums);
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
