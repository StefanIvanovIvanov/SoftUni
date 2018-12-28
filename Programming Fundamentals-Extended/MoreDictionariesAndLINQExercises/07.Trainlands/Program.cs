using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace _07.Trainlands
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, Dictionary<string, long>> trains = new Dictionary<string, Dictionary<string, long>>();
            string entry = Console.ReadLine();

            while (entry != "It's Training Men!")
            {
                string[] tokens = entry
                    .Split(new char[] {' ', '-', '>', '=', ':'}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (tokens.Length > 2)
                {
                    string trainName = tokens[0];
                    string wagonName = tokens[1];
                    long wagonPower = long.Parse(tokens[2]);

                    if (!trains.ContainsKey(trainName))
                    {
                        trains.Add(trainName, new Dictionary<string, long>());
                    }
                    trains[trainName].Add(wagonName, wagonPower);

                }
                else if (entry.Contains('='))
                {
                    string trainName = tokens[0];
                    string otherTrainName = tokens[1];

                    if (!trains.ContainsKey(trainName))
                    {
                        trains.Add(trainName, new Dictionary<string, long>());
                    }
                    trains[trainName].Clear();
                    foreach (var wagon in trains[otherTrainName])
                    {
                        trains[trainName].Add(wagon.Key, wagon.Value);
                    }
                }
                else if (entry.Contains("->"))
                {
                    string trainName = tokens[0];
                    string otherTrainName = tokens[1];

                    if (!trains.ContainsKey(trainName))
                    {
                        trains.Add(trainName, new Dictionary<string, long>());
                    }

                    foreach (var wagon in trains[otherTrainName])
                    {
                        trains[trainName].Add(wagon.Key, wagon.Value);
                    }
                    trains.Remove(otherTrainName);

                }
                entry = Console.ReadLine();             
            }
            //Dictionary<trains, Dictionary<wagons, power>>
            foreach (var t in trains.OrderByDescending(x => x.Value.Values.Sum()).ThenBy(z => z.Value.Keys.Count))
            {
                Console.WriteLine($"Train: {t.Key}");
                foreach (var w in t.Value.OrderByDescending(x=>x.Value))
                {
                    Console.WriteLine($"###{w.Key} - {w.Value}");
                }
            }
        }
    }
}
