using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _02.ExtractSentencesByKeyword
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = Console.ReadLine();
            string text = Console.ReadLine();

            string[] sentences = text.Split(new[] { '.', '?', '!' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string sentence in sentences)
            {
                string[] words = Regex.Split(sentence, "[^A-Za-z]");
                if (words.Contains(pattern))
                {
                    Console.WriteLine(sentence.Trim());
                }
            }
        }
    }
}