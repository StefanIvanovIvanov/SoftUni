using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.NSA
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> countries=new Dictionary<string, Dictionary<string, int>>();

            string entry = Console.ReadLine();

            while (entry != "quit")
            {
                string[] tokens = entry
                    .Split(new[] {' ', '-', '>'}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string countryName = tokens[0];
                string spyName = tokens[1];
                int daysInService = int.Parse(tokens[2]);

                if (!countries.ContainsKey(countryName))
                {
                    countries.Add(countryName, new Dictionary<string, int>());
                }
                if (!countries[countryName].ContainsKey(spyName))
                {
                    countries[countryName].Add(spyName, daysInService);
                }
                else
                {
                    countries[countryName][spyName] = daysInService;
                }
              entry = Console.ReadLine();
            }
            foreach (var country in countries.OrderByDescending(x=>x.Value.Count))
            {
                Console.WriteLine($"Country: {country.Key}");
                foreach (var spy in country.Value.OrderByDescending(x=>x.Value))
                {
                    Console.WriteLine($"**{spy.Key} : {spy.Value}");
                }
            }
        }
    }
}