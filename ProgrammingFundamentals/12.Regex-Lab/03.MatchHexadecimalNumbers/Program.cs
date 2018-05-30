using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03.MatchHexadecimalNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"\b(?:0x)?[0-9A-F]+\b";

            string[] numbers = Regex.Matches(input, pattern).Cast<Match>().Select(a => a.Value).ToArray();

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}