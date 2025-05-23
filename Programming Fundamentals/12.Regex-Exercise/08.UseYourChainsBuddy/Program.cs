﻿using System;
using System.IO;
using System.Text.RegularExpressions;

namespace _08.UseYourChainsBuddy
{
    class Program
    {
        static void Main(string[] args)
        {
            string html = Console.ReadLine();

            string pattern = @"<p>(.[^\/]+)<\/p>";
            string regex = @"[^a-z0-9]+";

            Regex words = new Regex(pattern);
            MatchCollection matches = words.Matches(html);
            string encrypted = "";
            for (int i = 0; i < matches.Count; i++)
            {
                string temp = matches[i].Groups[1].Value;
                encrypted += Regex.Replace(temp, regex, word => " ");
            }

            string manual = "";
            for (int i = 0; i < encrypted.Length; i++)
            {
                if (encrypted[i] >= 'a' && encrypted[i] <= 'm')
                {
                    manual += (char)(encrypted[i] + 13);
                }
                else if (encrypted[i] >= 'n' && encrypted[i] <= 'z')
                {
                    manual += (char)(encrypted[i] - 13);
                }
                else if (Char.IsDigit(encrypted[i]) || Char.IsWhiteSpace(encrypted[i]))
                {
                    manual += encrypted[i];
                }
            }
            Console.WriteLine(manual);
        }
    }   
}