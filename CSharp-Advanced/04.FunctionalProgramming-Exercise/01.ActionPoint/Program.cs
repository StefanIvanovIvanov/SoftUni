using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ActionPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            Action<string[]> print = Print;
            print(array);
        }

        static void Print(string[] input)
        {
            Console.WriteLine(string.Join(Environment.NewLine, input));
        }
    }
}
