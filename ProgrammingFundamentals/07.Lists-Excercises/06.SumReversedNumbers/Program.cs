using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _06.SumReversedNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().
                Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            int sum = 0;

            foreach (string number in input)
            {
                char[] array = number.ToCharArray();
                array = array.Reverse().ToArray();
                int num = int.Parse(new string(array));
                sum = sum + num;
            }
            Console.WriteLine(sum);
        }
    }
}