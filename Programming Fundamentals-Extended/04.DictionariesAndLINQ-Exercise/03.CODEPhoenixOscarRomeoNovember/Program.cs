using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.CODEPhoenixOscarRomeoNovember
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, HashSet<string>> dict = new Dictionary<string, HashSet<string>>();
           List<string> check = new List<string>();
            string input = Console.ReadLine();

            while (input != "Blaze it!")
            {
                string[] tokens = input.Split(new char[] { '-', '>', ' ' }, StringSplitOptions.RemoveEmptyEntries).
                    ToArray();

                string creature = tokens[0];
                string squadMate = tokens[1];

                check.Add(squadMate + "" + creature);

                if (!dict.ContainsKey(creature))
                {
                    dict.Add(creature, new HashSet<string>());
                }
                           
                if (creature == squadMate || check.Contains(creature + "" + squadMate))
                {
                    dict[squadMate].Remove(creature);
                    input = Console.ReadLine();
                    continue;
                }
                dict[creature].Add(squadMate);
                input = Console.ReadLine();
            }

            foreach (var creature in dict.OrderByDescending(x => x.Value.Count))
            {
                Console.WriteLine($"{creature.Key} : {string.Join(" ", creature.Value.Count)}");
            }
        }
    }
}