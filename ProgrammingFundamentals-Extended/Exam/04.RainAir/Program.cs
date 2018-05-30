using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.RainAir
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<int>> customersDictionary = new Dictionary<string, List<int>>();
            //CustNames<listOfFlights>
            string entry = Console.ReadLine();



            while (entry != "I believe I can fly!")
            {

                if (entry.Contains('='))
                {
                    string[] tokens = entry
                        .Split(new[] {' ', '='}, StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                    string customer1 = tokens[0];
                    string customer2 = tokens[1];
                    customersDictionary[customer1].Clear();
                    foreach (var flight in customersDictionary[customer2])
                    {
                        customersDictionary[customer1].Add(flight);
                    }


                }
                else
                {
                    string[] tokens = entry
                        .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                    string customerName = tokens[0];
                    List<int> flights = new List<int>();
                    for (int i = 1; i < tokens.Length; i++)
                    {
                        flights.Add(int.Parse(tokens[i]));
                    }

                    if (!customersDictionary.ContainsKey(customerName))
                    {
                        customersDictionary.Add(customerName, new List<int>());
                    }
                    foreach (var flight in flights)
                    {
                        customersDictionary[customerName].Add(flight);
                    }
                    flights.Clear();
                }

                entry = Console.ReadLine();
            }

            foreach (var c in customersDictionary.OrderByDescending(x=>x.Value.Count).ThenBy(z=>z.Key))
            {
                Console.Write($"#{c.Key}");
                Console.WriteLine($" ::: {string.Join(", ",c.Value.OrderBy(x=>x))}");
            }
        }
    }
}
