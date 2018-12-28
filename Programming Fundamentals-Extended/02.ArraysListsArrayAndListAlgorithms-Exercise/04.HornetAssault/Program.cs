using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.HornetAssault
{
    class Program
    {
        static void Main(string[] args)
        {
            List<long> beehives = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse).ToList();

            List<long> hornets = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse).ToList();

            for (int i = 0; i < beehives.Count; i++)
            {
                long power = hornets.Sum();
                beehives[i] -= power;
                if (beehives[i] >= 0)
                {
                    hornets.Remove(hornets[0]);
                    if (hornets.Count == 0)
                    {
                        break;
                    }
                }
            }
            beehives = beehives.Where(bees => bees > 0).ToList();
            if (beehives.Count > 0)
            {
                Console.WriteLine(String.Join(" ", beehives));
            }
            else
            {
                Console.WriteLine(String.Join(" ", hornets));
            }
        }
    }
}