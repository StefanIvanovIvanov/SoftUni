using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniKaraoke
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine()
                .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim())
                .ToArray();

            string[] songs = Console.ReadLine()
                .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim())
                .ToArray();

            //The input must be trimmed to work correctly.

            Dictionary<string, List<string>> winners = new Dictionary<string, List<string>>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "dawn")
                {
                    break;
                }
                string[] arrgs = input
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim())
                    .ToArray();
                string singer = arrgs[0];
                string song = arrgs[1];
                string awards = arrgs[2];
                if (!names.Any(s => s == singer) || !songs.Any(s => s == song))
                {
                    continue;
                }
                else
                {
                    if (!winners.ContainsKey(singer))
                    {
                        winners.Add(singer, new List<string>());
                        winners[singer].Add(awards);
                    }
                    else
                    {
                        winners[singer].Add(awards);
                    }
                }
            }

            if (winners.Count == 0)
            {
                Console.WriteLine("No awards");
            }
            else
            {
                foreach (var singer in winners.OrderByDescending(x => x.Value.Distinct().Count()))
                {
                    Console.WriteLine($"{singer.Key}: {singer.Value.Distinct().Count()} awards");
                    foreach (var award in singer.Value.OrderBy(x => x).Distinct())
                    {
                        Console.WriteLine("--" + award);
                    }
                }
            }
        }
    }
}