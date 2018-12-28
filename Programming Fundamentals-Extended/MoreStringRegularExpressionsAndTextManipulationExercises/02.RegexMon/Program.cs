using System;
using System.Text.RegularExpressions;

namespace _02.RegexMon
{
    class Program
    {
        static void Main(string[] args)
        {
            string didimonPattern = @"[^A-Za-z-]+";
            string bojomon = @"[A-Za-z]+-[A-Za-z]+";
            string text = Console.ReadLine();
            while (true)
            {
                Match didimonMatch = Regex.Match(text, didimonPattern);
                if (didimonMatch.Success)
                {
                    Console.WriteLine(didimonMatch.Value);
                    text = text.Substring(didimonMatch.Index + didimonMatch.Value.Length);
                }
                else
                {
                    break;
                }
                Match bojomonMatch = Regex.Match(text, bojomon);
                if (bojomonMatch.Success)
                {
                    Console.WriteLine(bojomonMatch.Value);
                    text = text.Substring(bojomonMatch.Index + bojomonMatch.Value.Length);
                }
                else
                {
                    break;
                }
            }
        }
    }
}