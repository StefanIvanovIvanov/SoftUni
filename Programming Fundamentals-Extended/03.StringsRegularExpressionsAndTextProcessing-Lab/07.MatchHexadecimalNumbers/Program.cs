using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _07.MatchHexadecimalNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\b(?:0x)?[0-9A-F]+\b";
            string text = Console.ReadLine();

            MatchCollection matches = Regex.Matches(text, pattern);

            string[] result = matches.Cast<Match>().Select(m => m.Value).ToArray();
            Console.WriteLine(string.Join(" ", result));
        }
    }
}