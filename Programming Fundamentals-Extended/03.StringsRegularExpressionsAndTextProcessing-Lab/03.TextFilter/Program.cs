using System;
using System.Linq;

namespace _03.TextFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] bannedWords = Console.ReadLine()
                .Split(new[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            string text = Console.ReadLine();

            foreach (var word in bannedWords)
            {
                string newWord = new string('*', word.Length);
                text = text.Replace(word, newWord);
            }
            Console.WriteLine(text);
        }
    }
}