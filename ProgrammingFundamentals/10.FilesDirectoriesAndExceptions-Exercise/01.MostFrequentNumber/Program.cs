using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _01.MostFrequentNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllText("input.txt");
            int[] numbers = input.Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            
            Dictionary<int, int> dict = new Dictionary<int, int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (dict.ContainsKey(numbers[i]))
                {
                    dict[numbers[i]]++;
                }
                else
                {
                    dict[numbers[i]] = 1;
                }
            }
            int mostCommonNumber = 0;
            int highestCount = 0;

            foreach (KeyValuePair <int, int> pair in dict)
            {
                if (pair.Value > highestCount)
                {
                    mostCommonNumber = pair.Key;
                    highestCount = pair.Value;
                }
            }
            File.WriteAllText("output.txt", mostCommonNumber.ToString());
        }
    }
}