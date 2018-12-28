using System;
using System.Collections.Generic;

namespace _03.AMinerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            bool canContinue = true;
            Dictionary<string, int> mats = new Dictionary<string, int>();

            while (canContinue)
            {
                string material = Console.ReadLine();

                int quantity = 0;
                if (material == "stop")
                {
                    canContinue = false;
                    PrintSortedResults(mats);
                    break;
                }
                else
                {
                    quantity = int.Parse(Console.ReadLine());
                }

                if (mats.ContainsKey(material))
                {
                    mats[material] += quantity;
                }
                else
                {
                    mats.Add(material, quantity);
                }

            }
        }

        private static void PrintSortedResults(Dictionary<string, int> mats)
        {
            foreach (KeyValuePair<string, int> materials in mats)
            {
                Console.WriteLine($"{materials.Key} -> {materials.Value}");
            }
        }
    }
}