using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.CODEPhoenixOscarRomeoNovember
{
    class Program
    {
        static void Main(string[] args)
        {
            string entry = Console.ReadLine();
            Dictionary<string, HashSet<string>>creatures=new Dictionary<string, HashSet<string>>();
            while (entry != "Blaze it!")
            {
                string[] tokens = entry.Split(new string[] {"->"}, StringSplitOptions.RemoveEmptyEntries).Select(x=>x.Trim()).ToArray();

                string creature = tokens[0];
                string squadMate = tokens[1];
                if (creature != squadMate)
                {
                    if (!creatures.ContainsKey(creature))
                    {
                        creatures.Add(creature, new HashSet<string>());

                    }
                    if (!creatures[creature].Contains(squadMate))
                    {
                        creatures[creature].Add(squadMate);
                    }

                    if (creatures.ContainsKey(squadMate) && creatures[squadMate].Contains(creature))
                    {
                        creatures[squadMate].Remove(creature);
                        creatures[creature].Remove(squadMate);
                    }
                    if (creature == squadMate)
                    {
                        creatures[squadMate].Remove(creature);
                        creatures[creature].Remove(squadMate);
                    }
                }
                creatures[creature].Distinct();
                entry = Console.ReadLine();
            }
            foreach (var c in creatures.OrderByDescending(x=>x.Value.Count))
            {
                Console.WriteLine($"{c.Key} : {c.Value.Count}");
            }
        }
    }
}
