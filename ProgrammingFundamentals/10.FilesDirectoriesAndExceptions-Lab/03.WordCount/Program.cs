using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _03.WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] text = File.ReadAllText("text.txt").ToLower().Split(new []{' ', '-', '!', '.', '?', ',', '\r', '\n'}, StringSplitOptions.RemoveEmptyEntries);
            string[] words = File.ReadAllText("words.txt").Split();
            Dictionary<string, int> count=new Dictionary<string, int>();

            foreach (var word in words)
            {
                count[word] = 0;
            }
            foreach (var word in text)
            {
                if (count.ContainsKey(word))
                {
                    count[word]++;
                }
            }
            File.WriteAllText("result.txt", "");

            foreach (var countedWord in count.OrderByDescending(w=>w.Value))
            {
                if(words.Contains(countedWord.Key))
                {
                    File.AppendAllText("result.txt", countedWord.Key + " - " + countedWord.Value+Environment.NewLine);
                }
            }
        }
    }
}