using System;
using System.Linq;

namespace _06.ReverseAnArrayOfStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine().Split(' ').ToArray();
            Console.WriteLine(string.Join(" ", arr.Reverse()));
        }
    }
}