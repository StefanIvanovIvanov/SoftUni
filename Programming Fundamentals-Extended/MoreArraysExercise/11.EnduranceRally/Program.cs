using System;
using System.Linq;

namespace _11.EnduranceRally
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] drivers = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            double[] track = Console.ReadLine().Split().Select(double.Parse).ToArray();
            int[] checkpoints = Console.ReadLine().Split().Select(int.Parse).ToArray();

            foreach (var driver in drivers)
            {
                char firstLeter = driver.First();
                double fuel = firstLeter;
                int reached = 0;
                for (int i = 0; i < track.Length; i++)
                {
                    bool isCheckpoint = false;

                    if (checkpoints.Any(c => c == i))
                    {
                        isCheckpoint = true;
                    }

                    if (isCheckpoint)
                    {
                        fuel += track[i];
                    }
                    else
                    {
                        fuel -= track[i];
                    }
                    if (fuel <= 0)
                    {
                        reached = i;
                        break;
                    }
                }
                if (fuel > 0)
                {
                    Console.WriteLine($"{driver} - fuel left {fuel:f2}");
                }
                else
                {
                    Console.WriteLine($"{driver} - reached {reached}");
                }
            }
        }
    }
}