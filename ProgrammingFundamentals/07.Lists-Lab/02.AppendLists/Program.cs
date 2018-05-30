using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _02.AppendLists
{
    class Program
    {
        static void Main()
        {
            List<string> input = Console.ReadLine()
                .Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            input.Reverse();

            Console.WriteLine(string.Join(" ", input));

        }
    }
}