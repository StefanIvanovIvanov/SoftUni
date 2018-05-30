using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.OddOccurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();

            string[] intput = Console.ReadLine().Split().ToArray();
            foreach (string w in intput)
            {
                string word = w.ToLower();

                if (dict.ContainsKey(word))
                {
                    dict[word] += 1;
                }
                else
                {
                    dict.Add(word, 1);
                }
            }
            List<string>result=new List<string>();
            foreach (KeyValuePair<string, int> pair in dict)
            {
                if (pair.Value % 2 != 0)
                {
                    result.Add(pair.Key);
                }
            }
            Console.WriteLine(string.Join(", ",result));
        }
    }
}