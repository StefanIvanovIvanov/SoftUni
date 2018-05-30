using System;
using System.Text.RegularExpressions;

namespace _05.MatchNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var pattern = @"(^|(?<=\s))-?\d+(\.\d+)?($|(?=\s))";
            var strings = Console.ReadLine();

            var numbers = Regex.Matches(strings, pattern);

            foreach (Match number in numbers)
            {
                Console.Write(number.Value+" ");
            }
            Console.WriteLine();
        }
    }
}