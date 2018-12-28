using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace _05.PokemonEvolution
{
    class Program
    {
        static void Main(string[] args)
        {
            string entry = Console.ReadLine();
            Dictionary<string, List<string>> pokemon = new Dictionary<string, List<string>>();

            while (entry != "wubbalubbadubdub")
            {
                string[] tokens = entry
                    .Split(new[] { ' ', '-', '>' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (tokens.Length > 1)
                {
                    string name = tokens[0];
                    string type = tokens[1];
                    string index = tokens[2];

                    if (!pokemon.ContainsKey(name))
                    {
                        pokemon.Add(name, new List<string>());
                    }
                    pokemon[name].Add($"{type} <-> {index}");
                }
                else
                {
                    string name = tokens[0];
                    if (pokemon.ContainsKey(name))
                    {
                        Console.WriteLine($"# {name}");
                        foreach (var typeIndex in pokemon[name])
                        {
                            Console.WriteLine(typeIndex);
                        }
                    }
                }
                entry = Console.ReadLine();
            }
            foreach (var p in pokemon)
            {
                Console.WriteLine($"# {p.Key}");
                foreach (var typeIndex in p.Value.OrderByDescending(x => int.Parse(x.Split(new[] { " <-> " }, StringSplitOptions.None).Skip(1).First())))
                {
                    Console.WriteLine(typeIndex);
                }

            }
        }
    }
}