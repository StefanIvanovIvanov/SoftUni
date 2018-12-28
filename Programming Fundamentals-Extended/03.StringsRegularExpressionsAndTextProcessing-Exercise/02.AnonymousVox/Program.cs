using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.AnonymousVox
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            List<string> placeholders= Console.ReadLine()
                .Split(new[] {'{', '}'},StringSplitOptions.RemoveEmptyEntries)
                .ToList();
           
            string pattern = @"([A-Za-z]+)(.*)(\1)";

            MatchCollection matches = Regex.Matches(text, pattern);

            List<string> toBeReplaced = new List<string>();
            int count = 0;
            foreach (Match m in matches)
            {
                string toReplace = m.Groups[1].Value+ placeholders[count++]+ m.Groups[3].Value;
                text = text.Replace(m.Value, toReplace);
            }
            Console.WriteLine(text);
        }
    }
}