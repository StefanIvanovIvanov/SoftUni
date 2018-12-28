using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.ShortWordsSorted
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().ToLower()
                .Split(new char[] {'.' , ',', ':', ';', '(', ')', '[', ']', '"', '\'', '/', '!', '?', ' ', '\\' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            List<string> result = new List<string>();

            foreach (var word in input)
            {
                if (word.Length < 5)
                {
                    result.Add(word);
                }
            }

            //must not be a list
            var newReslt = result.OrderBy(a => a).Distinct();

            Console.WriteLine(String.Join(", ", newReslt));
        }
    }
}