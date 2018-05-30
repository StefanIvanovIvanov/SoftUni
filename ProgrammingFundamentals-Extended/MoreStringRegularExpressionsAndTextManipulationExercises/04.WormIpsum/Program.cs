﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;
using System.Threading;

namespace _04.WormIpsum
{
    class Program
    {
        static void Main(string[] args)
        {

            var sentenceReg = new Regex(@"^[A-Z][^\.]*\.$");
            var wordsReg = new Regex(@"[^\s,\.]+");

            var inputLine = Console.ReadLine();
            while (!inputLine.Equals("Worm Ipsum"))
            {
                var sentenceMatch = sentenceReg.Match(inputLine);
                if (sentenceMatch.Success)
                {
                    var wordsMatches = wordsReg.Matches(inputLine);
                    foreach (Match match in wordsMatches)
                    {
                        var currentWord = match.Value;
                        if (currentWord.Length != currentWord.Distinct().Count())
                        {
                            var symbol = currentWord.GroupBy(x => x).OrderByDescending(x => x.Count()).First().Key;
                            var newWord = string.Concat(Enumerable.Repeat(symbol, currentWord.Length));
                            inputLine = Regex.Replace(inputLine, currentWord, newWord);

                        }
                    }

                    Console.WriteLine(inputLine);
                }

                inputLine = Console.ReadLine();
            }

        }
    }
}