using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _06.MatchPhoneNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string pattern = @"\+359( |-)2\1[0-9]{3}\1[0-9]{4}\b";
            MatchCollection phoneMatches = Regex.Matches(text, pattern);
            string[] matches = phoneMatches.Cast<Match>().Select(m => m.Value.Trim()).ToArray();

            Console.WriteLine(string.Join(", ",matches));
        }
    }
}