using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.Entertrain
{
    class Program
    {
        static void Main(string[] args)
        {
            int power = int.Parse(Console.ReadLine());
            List<int> wagons = new List<int>();
            string input = Console.ReadLine();
            while (input != "All ofboard!")
            {
                int weight = int.Parse(input);
                wagons.Add(weight);
                int sum = wagons.Sum();
                double average = 0;
                if (sum > power)
                {
                    average = wagons.Average();
                    var nearest = wagons.OrderBy(x => Math.Abs((long)x - average)).First();
                    wagons.Remove(nearest);
                }
                input = Console.ReadLine();
            }
            wagons.Reverse();
            wagons.Add(power);
            Console.WriteLine(string.Join(" ", wagons));
        }
    }
}