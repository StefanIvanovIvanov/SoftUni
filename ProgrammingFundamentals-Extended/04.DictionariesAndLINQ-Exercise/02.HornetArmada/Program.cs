using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.HornetArmada
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, long>legionAndActivity=new Dictionary<string, long>();
            Dictionary<string,Dictionary<string, long>>legionsSoldersAndCount=new Dictionary<string, Dictionary<string, long>>();
            long n = long.Parse(Console.ReadLine());
            for (long i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(new[] {'=', '-', '>', ':', ' '}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string legionName = tokens[1];
                long lastActivity = long.Parse(tokens[0]);
                string solderType = tokens[2];
                long soldierCount = long.Parse(tokens[3]);
             

                if (!legionsSoldersAndCount.ContainsKey(legionName))
                {
                    legionsSoldersAndCount.Add(legionName,new Dictionary<string, long>());
                    legionAndActivity.Add(legionName, lastActivity);
                }
                if (!legionsSoldersAndCount[legionName].ContainsKey(solderType))
                {
                    legionsSoldersAndCount[legionName].Add(solderType, soldierCount);
                }
                else
                {
                    legionsSoldersAndCount[legionName][solderType] += soldierCount;
                }

                if (lastActivity > legionAndActivity[legionName])
                {
                    legionAndActivity[legionName] = lastActivity;
                }
            }
            string[] command = Console.ReadLine()
                .Split(new[] {'\\'}, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            if (command.Length > 1)
            {
                long currentActivity = long.Parse(command[0]);
                string currentSoldierType = command[1];

                foreach (var legion in legionsSoldersAndCount.Where(e=>legionsSoldersAndCount[e.Key].ContainsKey(currentSoldierType)).OrderByDescending(k=>k.Value[currentSoldierType]))
                {
                    if (legionAndActivity[legion.Key] < currentActivity)
                    {
                        Console.WriteLine($"{legion.Key} -> {legion.Value[currentSoldierType]}");
                    }
                }
            }
            else
            {
                foreach (var legion in legionAndActivity.OrderByDescending(x=>x.Value))
                {
                    string currentSoldierType = command[0];

                    if (legionsSoldersAndCount[legion.Key].ContainsKey(currentSoldierType))
                    {
                        Console.WriteLine($"{legion.Value} : {legion.Key}");
                    }
                }   
            }
        }
    }
}