using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _07.RageQuit
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"([^0-9]+)([0-9]+)";
            string input = Console.ReadLine();
            MatchCollection matches = Regex.Matches(input, pattern);
            StringBuilder sb = new StringBuilder();
            foreach (Match m in matches)
            {
                string message = m.Groups[1].Value.ToUpper();
   
                int number = int.Parse(m.Groups[2].Value);
                for (int i = 0; i < number; i++)
                {
                    sb.Append(message);
                }
            }
            int uniqueSymbols = sb.ToString().Distinct().Count();
            Console.WriteLine($"Unique symbols used: {uniqueSymbols}");
            Console.WriteLine(sb);
        }
    }
}