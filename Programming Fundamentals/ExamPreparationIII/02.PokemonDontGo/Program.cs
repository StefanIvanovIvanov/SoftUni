using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace PokemonDontGo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> pokemon = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();
            List<int> removed = new List<int>();
            int index = int.Parse(Console.ReadLine());
            int removedElement = 0;
            while (true)
            {
                if (index < 0)
                {
                    removedElement = pokemon[0];
                    pokemon[0] = pokemon[pokemon.Count - 1];
                }
                else if (index >= pokemon.Count)
                {
                    removedElement = pokemon[pokemon.Count - 1];
                    pokemon[pokemon.Count - 1] = pokemon[0];
                }
                else
                {
                    removedElement = pokemon[index];
                    pokemon.RemoveAt(index);
                }

                removed.Add(removedElement);


                for (int i = 0; i < pokemon.Count; i++)
                {
                    if (pokemon[i] <= removedElement)
                    {
                        pokemon[i] += removedElement;
                    }
                    else
                    {
                        pokemon[i] -= removedElement;
                    }
                }
                if (pokemon.Count == 0)
                {
                    break;
                }
                int remember = index;

                if (index < 0)
                {
                    pokemon[0] = pokemon[pokemon.Count - 1];
                }
                if (index > remember)
                {
                    pokemon[pokemon.Count - 1] = pokemon[0];
                }
                index = int.Parse(Console.ReadLine());
            }
            Console.WriteLine(removed.Sum());
        }
    }
}