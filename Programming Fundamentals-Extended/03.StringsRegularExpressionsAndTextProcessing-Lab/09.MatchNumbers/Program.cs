using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace _09.MatchNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(^|\s)-?\d+(\.\d+)?($|(?=\s))";
            string text = Console.ReadLine();

            MatchCollection matches = Regex.Matches(text, pattern);
            List<string> results = new List<string>();
            foreach (Match number in matches)
            {
                results.Add(number.Value);
            }
            results = results.Select(n => n.Trim()).ToList();
            Console.WriteLine(string.Join(" ", results));
        }
    }
}