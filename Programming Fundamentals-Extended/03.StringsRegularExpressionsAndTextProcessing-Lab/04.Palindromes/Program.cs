using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _04.Palindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] words = input.Split(new[] {' ', ',', '.', '?', '!'},StringSplitOptions.RemoveEmptyEntries).Distinct().ToArray();
            List<string> palindromes = new List<string>();
            foreach (var w in words)
            {
                char[] reversedCharr = w.ToCharArray().Reverse().ToArray();
                string reversed = string.Join("", reversedCharr);
                if (w == reversed)
                {
                    palindromes.Add(w);
                }
            }
            Console.WriteLine(string.Join(", ", palindromes.OrderBy(x=>x)));
        }
    }
}