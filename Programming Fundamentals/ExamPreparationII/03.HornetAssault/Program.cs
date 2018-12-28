using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace HornetAssault
{
    class Program
    {
        static void Main(string[] args)
        {
            List<long> beehives = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse).ToList();

            List<long> hornets = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse).ToList();

            long powerHornets = 0;


            for (int i = 0; i < beehives.Count; i++)
            {
                powerHornets = hornets.Sum();
                if (beehives[i] >= powerHornets)
                {
                    beehives[i] = beehives[i] - powerHornets;
                    hornets.Remove(hornets[0]);
                }
                else
                {
                    beehives[i] = 0;
                }
                if (hornets.Count == 0)
                {
                    break;
                }
            }
            List<long> remainingBees = beehives.Where(b => b > 0).ToList();

            if (remainingBees.Count > 0)
            {
                Console.WriteLine(string.Join(" ", remainingBees));
            }
            else
            {
                Console.WriteLine(string.Join(" ", hornets));
            }
        }
    }
}