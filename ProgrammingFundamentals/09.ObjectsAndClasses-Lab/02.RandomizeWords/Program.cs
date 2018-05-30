using System;
using System.Linq;

namespace _02.RandomizeWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Random rnd = new Random();

            for (int i = 0; i < input.Length; i++)
            {
                var randomWord = rnd.Next(0, input.Length);
                var newRandomWord = rnd.Next(0, input.Length);

                string words = input[randomWord];
                input[randomWord] = input[newRandomWord];
                input[newRandomWord] = words;

            }
            Console.WriteLine(string.Join("\n", input));
        }
    }
}