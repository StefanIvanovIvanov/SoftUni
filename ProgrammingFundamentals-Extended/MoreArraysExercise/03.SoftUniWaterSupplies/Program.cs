using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.SoftUniWaterSupplies
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal totalAmountOfWater = long.Parse(Console.ReadLine());
            decimal[] bottles = Console.ReadLine()             
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(decimal.Parse).ToArray();
            long bottleCapacity = long.Parse(Console.ReadLine());
            List<long> notFilledBottlesIndexes = new List<long>();
            bool waterIsEnough = true;
            //even
            if (totalAmountOfWater % 2 == 0)
            {
                for (int i = 0; i < bottles.Length; i++)
                {
                    decimal toFill = bottleCapacity - bottles[i];
                    bottles[i] += toFill;
                    totalAmountOfWater -= toFill;
                    if (totalAmountOfWater <= 0)
                    {
                        waterIsEnough = false;
                        notFilledBottlesIndexes.Add(i);
                    }
                }
                if (waterIsEnough)
                {
                    Console.WriteLine("Enough water!");
                    Console.WriteLine($"Water left: {totalAmountOfWater}l.");
                }
                else
                {
                    Console.WriteLine("We need more water!");
                    Console.WriteLine($"Bottles left: {notFilledBottlesIndexes.Count}");
                    Console.WriteLine($"With indexes: {string.Join(", ",notFilledBottlesIndexes)}");
                    Console.WriteLine($"We need {Math.Abs(totalAmountOfWater)} more liters!");
                }
            }
            //odd
            else if(totalAmountOfWater % 2 != 0)
            {
                for (int i = bottles.Length-1; i >= 0; i--)
                {
                    decimal toFill = bottleCapacity - bottles[i];
                    bottles[i] += toFill;
                    totalAmountOfWater -= toFill;
                    if (totalAmountOfWater <= 0)
                    {
                        waterIsEnough = false;
                        notFilledBottlesIndexes.Add(i);
                    }
                }
                if (waterIsEnough)
                {
                    Console.WriteLine("Enough water!");
                    Console.WriteLine($"Water left: {totalAmountOfWater}l.");
                }
                else
                {
                    Console.WriteLine("We need more water!");
                    Console.WriteLine($"Bottles left: {notFilledBottlesIndexes.Count}");
                    Console.WriteLine($"With indexes: {string.Join(", ", notFilledBottlesIndexes)}");
                    Console.WriteLine($"We need {Math.Abs(totalAmountOfWater)} more liters!");
                }
            }
        }
    }
}