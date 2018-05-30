using System;
using System.Linq;

namespace _01.ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            char[] reversed = input.ToCharArray().Reverse().ToArray();
            Console.WriteLine(new string(reversed));
        }
    }
}