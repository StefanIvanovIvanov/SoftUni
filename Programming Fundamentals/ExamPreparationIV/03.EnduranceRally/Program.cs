using System;
using System.Collections.Generic;
using System.Linq;

namespace EdnuranceRally
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] racers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            double[] trackLayout = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();

            double[] checkpoints = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();

            double stamina = 0;
            foreach (var driver in racers)
            {
                stamina = driver.First();

                bool isCheckpoint = false;
                for (int i = 0; i < trackLayout.Length; i++)
                {
                    for (int j = 0; j < checkpoints.Length; j++)
                    {
                        if (i == checkpoints[j])
                        {
                            isCheckpoint = true;

                        }
                        else
                        {
                            continue;
                        }
                    }
                    if (isCheckpoint)
                    {
                        stamina += trackLayout[i];
                    }
                    else
                    {
                        stamina -= trackLayout[i];
                    }

                    if (stamina <= 0)
                    {
                        Console.WriteLine($"{driver} - reached {i}");
                        break;
                    }
                    isCheckpoint = false;
                }
                if (stamina > 0)
                {
                    Console.WriteLine($"{driver} - fuel left {stamina:f2}");
                }
            }
        }
    }
}