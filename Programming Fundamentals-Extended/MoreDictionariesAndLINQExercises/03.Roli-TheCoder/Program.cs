using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Roli_TheCoder
{
    class Program
    {
        static void Main(string[] args)
        {
            string entry = Console.ReadLine();            
            Dictionary<int, string>ids=new Dictionary<int, string>();
            Dictionary<string, HashSet<string>> events = new Dictionary<string, HashSet<string>>();
            while (entry != "Time for Code")
            {
                if (!entry.Contains('#'))
                {
                    entry = Console.ReadLine();
                    continue;
                }

                string[] tokens = entry
                    .Split(new[] {' ', '#'}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                int id = int.Parse(tokens[0]);
                string eventName = tokens[1];
                List<string>newParticipants = new List<string>();
                for (int i = 2; i < tokens.Length; i++)
                {
                    newParticipants.Add(tokens[i]);
                }
                if (newParticipants.Any(x => !x.StartsWith('@'.ToString())))
                {
                    entry = Console.ReadLine();
                    continue;
                }

                if (!ids.ContainsKey(id)&&!ids.ContainsValue(eventName))
                {
                    ids.Add(id, eventName);
                }

                if (ids.ContainsKey(id) && ids.ContainsValue(eventName) && !events.ContainsKey(eventName))
                {
                    events.Add(eventName, new HashSet<string>());

                }
                if (ids.ContainsKey(id) && ids.ContainsValue(eventName) && events.ContainsKey(eventName))
                {

                    for (int i = 0; i < newParticipants.Count; i++)
                    {
                        events[eventName].Add(newParticipants[i]);
                    }
                }
                    entry = Console.ReadLine();
            }

            foreach (var e in events.OrderByDescending(e=>e.Value.Count()).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{e.Key} - {e.Value.Count}");
              foreach (var p in e.Value.OrderBy(x=>x))
              {
                  Console.WriteLine(p);
              }
            }
        }
    }
}
