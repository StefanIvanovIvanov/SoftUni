using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.MatchPhoneNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\+359(-? ?)2\1\d{3}\1\d{4}\b"; //also @"\+359( |-)2\1\d{3}\1\d{4}\b"
            string phones = Console.ReadLine();

            var phoneMatches = Regex.Matches(phones, pattern);
            List<string> result = new List<string>();
            foreach (Match m in Regex.Matches(phones, pattern))
            {
                result.Add(m.ToString());
            }
            Console.WriteLine(String.Join(", ", result));
        }
    }
}