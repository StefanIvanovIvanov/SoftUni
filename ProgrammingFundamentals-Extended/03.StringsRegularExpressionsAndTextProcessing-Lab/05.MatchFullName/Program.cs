using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _05.MatchFullName
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string pattern = @"\b[A-Z][a-z]+ [A-Z][a-z]+\b";
            MatchCollection matches = Regex.Matches(text, pattern);
            List<string> result = new List<string>();
            foreach (Match m in matches)
            {
                result.Add(m.Value);
            }
            Console.WriteLine(string.Join(" ",result));
        }
    }
}