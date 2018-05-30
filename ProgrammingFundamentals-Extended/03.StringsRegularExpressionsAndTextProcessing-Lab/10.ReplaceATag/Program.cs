using System;
using System.Text.RegularExpressions;

namespace _10.ReplaceATag
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            while (input != "end")
            {
                string pattern = @"<a.*?href.*?=(.*)>(.*?)<\/a>";
                string replace = @"[URL href=$1]$2[/URL]";
                string result = Regex.Replace(input, pattern, replace);
                input = Console.ReadLine();
                Console.WriteLine(result);
            }
        }
    }
}