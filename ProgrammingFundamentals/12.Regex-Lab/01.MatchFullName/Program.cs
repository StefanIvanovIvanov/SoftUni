using System;
using System.Text.RegularExpressions;

namespace _01.MatchFullName
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"\b[A-Z][a-z]+ [A-Z][a-z]+\b";
            MatchCollection matches = Regex.Matches(input, pattern);

            foreach (Match name in matches)
            {
                Console.Write(name+" ");
            }
        }
    }
}