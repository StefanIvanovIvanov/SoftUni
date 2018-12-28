using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.HornetArmada
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, int>activtyLegion=new Dictionary<string, int>();
            Dictionary<string, Dictionary<string, int>>legionSoldeierTypeCount=new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] entry = Console.ReadLine()
                    .Split(new[] {'=', '-', '>', ':', ' '}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                int lastActivity = int.Parse(entry[0]);
                string legionName = entry[1];
                string soldierType = entry[2];
                int soldierCount = int.Parse(entry[3]);

                if (!activtyLegion.ContainsKey(legionName))
                {
                 activtyLegion.Add(legionName, lastActivity);   
                }
                if (!legionSoldeierTypeCount.ContainsKey(legionName))
                {
                    legionSoldeierTypeCount.Add(legionName,new Dictionary<string, int>());
                }
                if (!legionSoldeierTypeCount[legionName].ContainsKey(soldierType))
                {
                    legionSoldeierTypeCount[legionName].Add(soldierType, soldierCount);
                }
                else
                {
                    legionSoldeierTypeCount[legionName][soldierType] += soldierCount;
                }
                if (lastActivity > activtyLegion[legionName])
                {
                    activtyLegion[legionName] = lastActivity;
                }
            }
            string[] tokens = Console.ReadLine().Split(new[] {'\\'}).ToArray();

            if (tokens.Length > 1)
            {
                int currentActivity = int.Parse(tokens[0]);
                string currentSolderType = tokens[1];
                
                foreach (var legion in legionSoldeierTypeCount.Where(l=>legionSoldeierTypeCount[l.Key].ContainsKey(currentSolderType)).OrderByDescending(c=>c.Value[currentSolderType]))
                {
                    if (activtyLegion[legion.Key] < currentActivity)
                    {
                        Console.WriteLine($"{legion.Key} -> {legion.Value[currentSolderType]}");
                    }
                }
            }
            else
            {
                string currentSoldierType = tokens[0];

                foreach (var legion in activtyLegion.OrderByDescending(x=>x.Value))
                {
                    if (legionSoldeierTypeCount[legion.Key].ContainsKey(currentSoldierType))
                    {
                        Console.WriteLine($"{legion.Value} : {legion.Key}");
                    }
                }
            }
        }
    }
}
