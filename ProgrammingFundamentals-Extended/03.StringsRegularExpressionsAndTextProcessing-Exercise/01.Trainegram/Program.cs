using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01.Trainegram
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^(\<\[[^A-Za-z0-9]*\][\.]{1})+([\.]{1}\[[A-Za-z0-9]*\][\.]{1})*$";
            string input = Console.ReadLine();
            List<string>results = new List<string>();
            while (true)
            {
                if (input == "Traincode!")
                {
                    break;
                }
                Match match = Regex.Match(input, pattern);
                if (match.Success)
                {
                    results.Add(match.Value);
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(string.Join(Environment.NewLine, results));
        }
    }
}