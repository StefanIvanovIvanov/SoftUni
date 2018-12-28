using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _05.NetherRealms
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string healthPattern = @"[^0-9\+\-\*\/\.]";
            string damagePattern = @"[\-\+]?[\d]+(?:[\.]*[\d]+|[\d]*)";
            string damageMultiplierPattern = @"[\/\*]";

            List<string> demons = input
                .Split(new[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            demons.Sort();
            foreach (var demon in demons)
            {
                decimal health = 0;
                decimal damage = 0;

                MatchCollection healthStats = Regex.Matches(demon, healthPattern);
                MatchCollection damageStats = Regex.Matches(demon, damagePattern);
                MatchCollection damageMultiplier = Regex.Matches(demon, damageMultiplierPattern);

                foreach (Match m in healthStats)
                {
                    foreach (char number in m.ToString())
                    {
                        health += (decimal) number;
                    }
                }                                              
                foreach (var m in damageStats)
                {
                    damage += decimal.Parse(m.ToString());
                }
                foreach (Match m in damageMultiplier)
                {
                    if (m.Value.ToString() == "/")
                    {
                        damage /= 2;
                    }else if (m.Value.ToString() == "*")
                    {
                        damage *= 2;
                    }
                }
                Console.WriteLine($"{demon} - {health} health, {damage:f2} damage");
            }
        }
    }
}