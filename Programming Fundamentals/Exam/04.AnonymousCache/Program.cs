using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.AnonymousCache
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, long>> data = new Dictionary<string, Dictionary<string, long>>();
            List<string> cache = new List<string>();

            string input = Console.ReadLine();

            while (input != "thetinggoesskrra")
            {
                string[] tokens = input
                    .Split(new[] { ' ', '-', '>', '|' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (tokens.Length > 1)
                {
                    string dataSet = tokens[2];
                    string dataKey = tokens[0];
                    long dataSize = long.Parse(tokens[1]);

                    if (!data.ContainsKey(dataSet))
                    {
                        data.Add(dataSet, new Dictionary<string, long>());

                    }
                    data[dataSet][dataKey] = dataSize;
                }
                else
                {
                    cache.Add(tokens[0]);
                }
                input = Console.ReadLine();
            }
            data.ToList().Where(e => !cache.Contains(e.Key)).ToList().ForEach(e => data.Remove(e.Key));

            if (data.Count > 0)
            {
                var result = data.OrderByDescending(x => x.Value.Sum(e => e.Value)).First();
                Console.WriteLine($"Data Set: {result.Key}, Total Size: {result.Value.Sum(e => e.Value)}");
                foreach (var item in result.Value)
                {
                    Console.WriteLine($"$.{item.Key}");
                }
            }
        }
    }
}