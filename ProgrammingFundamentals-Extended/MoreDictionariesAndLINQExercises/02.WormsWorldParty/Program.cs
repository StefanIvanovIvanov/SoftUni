using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.WormsWorldParty
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, long> >teams=new Dictionary<string, Dictionary<string, long>>();
            //Dictionary   <teamName<wormName,wormScore>>
            
            string entry = Console.ReadLine();

            while (entry != "quit")
            {
                string[] tokens = entry
                    .Split(new[] {'-', '>'}, StringSplitOptions.RemoveEmptyEntries).Select(x=>x.Trim()).ToArray();

                string wormName = tokens[0];
                string teamName = tokens[1];
                long wormScore = long.Parse(tokens[2]);

                if (!teams.ContainsKey(teamName))
                {
                    teams.Add(teamName, new Dictionary<string, long>());
                }
                if (!teams.Any(x => x.Value.Keys.Any(e => e == wormName)))
                {
                    teams[teamName].Add(wormName, wormScore);
                }
                entry = Console.ReadLine();
            }         

            if (teams.Keys.Count > 0)
            {
                long place = 1;
                foreach (var team in teams.OrderByDescending(x => x.Value.Values.Sum())
                    .ThenByDescending(e => e.Value.Values.Sum()/e.Value.Keys.Count))
                {
                    Console.WriteLine($"{place++}. Team: {team.Key} - {team.Value.Values.Sum()}");
                    foreach (var worm in team.Value.OrderByDescending(x => x.Value))
                    {
                        Console.WriteLine($"###{worm.Key} : {worm.Value}");
                    }
                }
            }
        }
    }
}
