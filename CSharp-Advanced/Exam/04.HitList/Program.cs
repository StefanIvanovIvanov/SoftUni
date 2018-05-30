using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.HitList
{
    class Program
    {
        static void Main(string[] args)
        {
            int targetInfoIndex = int.Parse(Console.ReadLine());
            //name<key,value>
            Dictionary<string,Dictionary<string,string> >targets=new Dictionary<string, Dictionary<string, string>>();

            string input = Console.ReadLine();

            while (input != "end transmissions")
            {
                string[] tokens = input.Split(new[] {'=', ':', ';'}, StringSplitOptions.RemoveEmptyEntries).ToArray();
                string name = tokens[0];
                if (!targets.ContainsKey(name))
                {
                    targets.Add(name,new Dictionary<string, string>());
                }
                for (int i = 2; i < tokens.Length; i+=2)
                {
                    string key = tokens[i-1];
                    string value = tokens[i];

                    if (!targets[name].ContainsKey(key))
                    {
                        targets[name].Add(key, value);
                    }
                    else
                    {
                        targets[name][key] = value;
                    }
                }

                input = Console.ReadLine();
            }

            string[] kill = Console.ReadLine()
                .Split(new char[]{' '},StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string toKill = kill[1];

            int sum = 0;
            Console.WriteLine($"Info on {toKill}:");
            foreach (var info in targets[toKill].OrderBy(t=>t.Key))
            {
                sum += info.Key.Length;
                sum += info.Value.Length;
                Console.WriteLine($"---{info.Key}: {info.Value}");
            }
            Console.WriteLine($"Info index: {sum}");
            if (sum >= targetInfoIndex)
            {
                Console.WriteLine("Proceed");
            }
            else
            {
                Console.WriteLine($"Need {targetInfoIndex-sum} more info.");
            }
        }
    }
}
