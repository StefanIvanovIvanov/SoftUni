using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace RegexMon
{
    class Program
    {
        static void Main(string[] args)
        {
            string didimonPattern = @"[^A-Za-z-]+";
            string bojomonPattern = @"[A-Za-z]+-[A-Za-z]+";

            Regex regextDidi = new Regex(didimonPattern);
            Regex regexBojo = new Regex(bojomonPattern);

            string input = Console.ReadLine();
            while (true)
            {
                Match didiMonMatch = regextDidi.Match(input);

                if (didiMonMatch.Success)
                {
                    Console.WriteLine(didiMonMatch);
                }
                else
                {
                    return;
                }
                int firstSymbolDidi = didiMonMatch.Index;
                input = input.Substring(firstSymbolDidi + didiMonMatch.Length);

                Match bojoMonMatch = regexBojo.Match(input);

                if (bojoMonMatch.Success)
                {
                    Console.WriteLine(bojoMonMatch);
                }
                else
                {
                    return;
                }
                int firstSymbolBojo = bojoMonMatch.Index;
                input = input.Substring(firstSymbolBojo + bojoMonMatch.Length);
            }
        }
    }
}