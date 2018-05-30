using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace HornetArmada
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());

            List<string> input = new List<string>();

            Dictionary<string, long> soldierLegionActivity = new Dictionary<string, long>();

            Dictionary<string, Dictionary<string, long>> soldierTypeCount = new Dictionary<string, Dictionary<string, long>>();


            for (long i = 0; i < n; i++)
            {
                input = Console.ReadLine().Split(new string[] { " = ", " -> ", ":" }, StringSplitOptions.RemoveEmptyEntries).ToList();

                long lastActivity = long.Parse(input[0]);
                string legionName = input[1];
                string soldierType = input[2];
                long soldierCount = long.Parse(input[3]);

                if (!soldierLegionActivity.ContainsKey(legionName))
                {
                    soldierLegionActivity.Add(legionName, lastActivity);

                    soldierTypeCount.Add(legionName, new Dictionary<string, long>());

                    soldierTypeCount[legionName].Add(soldierType, soldierCount);
                }
                else
                {
                    if (lastActivity > soldierLegionActivity[legionName])
                    {
                        soldierLegionActivity[legionName] = lastActivity;
                    }

                    if (!soldierTypeCount[legionName].ContainsKey(soldierType))
                    {
                        soldierTypeCount[legionName].Add(soldierType, soldierCount);
                    }
                    else
                    {
                        soldierTypeCount[legionName][soldierType] += soldierCount;
                    }
                }
            }
            string input2 = Console.ReadLine();

            if (input2.Contains('\\'))
            {
                Dictionary<string, long> printDic = new Dictionary<string, long>();
                string[] tokens2 = input2.Split('\\').ToArray();
                long wantedActivityLEss = long.Parse(tokens2[0]);
                string type = tokens2[1];

                foreach (var e in soldierLegionActivity)
                {
                    if (soldierTypeCount[e.Key].ContainsKey(type))
                    {
                        if (e.Value < wantedActivityLEss)
                        {
                            printDic.Add(e.Key, soldierTypeCount[e.Key][type]);
                        }
                    }
                }

                foreach (var pair in printDic.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine(pair.Key + " -> " + pair.Value);
                }
            }
            else
            {
                string soldierType = input2;
                Dictionary<string, long> dicPrint = new Dictionary<string, long>();
                foreach (var legion in soldierTypeCount)
                {
                    if (legion.Value.ContainsKey(soldierType))
                    {
                        long lastActivity = soldierLegionActivity[legion.Key];
                        string legionName = legion.Key;
                        dicPrint.Add(legionName, lastActivity);
                    }
                }
                foreach (var e in dicPrint.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine(e.Value + " : " + e.Key);
                }
            }

        }
    }
}
