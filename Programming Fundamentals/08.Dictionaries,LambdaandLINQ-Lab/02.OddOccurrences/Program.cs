using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.OddOccurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().ToLower()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var count = new Dictionary<string, int>();

            foreach (var word in input)
            {
              if(count.ContainsKey(word))
              {
                  count[word]++;
              }
              else
              {
                  count[word] = 1;
              }
            }
            var result= new List<string>();

            foreach (var pair in count)
            {
                if (pair.Value % 2 != 0)
                {
                    result.Add(pair.Key);
                }
            }
            Console.WriteLine(String.Join(", ", result));
        }
    }
}