using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Trainlands
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, long>> trains = new Dictionary<string, Dictionary<string, long>>();
            //trainName<wagons,power>

            string input = Console.ReadLine();

            while (input != "It's Training Men!")
            {

                bool flag = false;
                if (input.IndexOf('=') != -1)
                {
                    flag = true;
                }


                string[] data = input.Split("=->: ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                if (data.Length > 2)
                {
                    string tranName = data[0];
                    string wagonName = data[1];
                    long wagonPower = long.Parse(data[2]);

                    if (!trains.ContainsKey(tranName))
                    {
                        trains.Add(tranName, new Dictionary<string, long>());
                    }
                    trains[tranName][wagonName] = wagonPower;
                }
                else
                {
                    string trainName = data[0];
                    string otherTrainName = data[1];

                    if (flag)
                    {
                        trains.Remove(trainName);
                    }

                    if (!trains.ContainsKey(trainName))
                    {
                        trains.Add(trainName,new Dictionary<string, long>());
                    }

                    foreach (var wagon in trains[otherTrainName])
                    { 
                      trains[trainName].Add(wagon.Key, wagon.Value);  
                    }
                    if (!flag)
                    {
                        trains.Remove(otherTrainName);
                    }
                }
                 input = Console.ReadLine();
            }

            //trainName<wagons,power>
            foreach (var train in trains.OrderByDescending(x => x.Value.Sum(e=>e.Value)).ThenBy(x=>x.Value.Count))
            {
                Console.WriteLine($"Train: {train.Key}");
                foreach (var wagon in train.Value.OrderByDescending((x=>x.Value)))
                {
                    Console.WriteLine($"###{wagon.Key} - {wagon.Value}");
                }
            }
        }
    }
}
