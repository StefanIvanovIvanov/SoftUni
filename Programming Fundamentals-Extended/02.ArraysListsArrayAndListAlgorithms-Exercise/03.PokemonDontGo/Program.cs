using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.PokemonDontGo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> pokemon = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();

            List<int>removed=new List<int>();

            while (pokemon.Count>0)
            {
                int index = int.Parse(Console.ReadLine());
                int removedPokemon = 0;

                if (index < 0)
                {
                    index = 0;
                    removedPokemon = pokemon[index];
                    removed.Add(removedPokemon);
                    pokemon[0] = pokemon[pokemon.Count - 1];
                }
                else if (index >= pokemon.Count)
                {
                    index = pokemon.Count - 1;
                    removedPokemon = pokemon[index];
                    removed.Add(removedPokemon);
                    pokemon[pokemon.Count - 1] = pokemon[0];
                }
                else
                {
                    removedPokemon = pokemon[index];
                    removed.Add(removedPokemon);
                    pokemon.RemoveAt(index);
                }
                
                for (int i = 0; i < pokemon.Count; i++)
                {
                    if (pokemon[i] <= removedPokemon)
                    {
                        pokemon[i] += removedPokemon;
                    }
                    else if (pokemon[i] > removedPokemon)
                    {
                        pokemon[i] -= removedPokemon;
                    }
                }
            }
            int sum = removed.Sum();
            Console.WriteLine(sum);
        }
    }
}