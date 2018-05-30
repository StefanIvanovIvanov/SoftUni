using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.SplitByWordCasing
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split(new char[] {',', ';', '.', '!','(', ')', '"', '\'', '\\', '/', '[', ']', ' ', ':'}, StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> lowercase = new List<string>();
            List<string> uppercase = new List<string>();
            List<string> others = new List<string>();

            for (int i = 0; i < input.Count; i++)
            {

                if (input[i].All(char.IsUpper))
                {
                    uppercase.Add(input[i]);
                }
                else if (input[i].All(char.IsLower))
                {
                    lowercase.Add(input[i]);
                }
                else
                {
                    others.Add(input[i]);
                }
            }
            Console.WriteLine("Lower-case: " + string.Join(", ", lowercase));
            Console.WriteLine("Mixed-case: " + string.Join(", ", others));
            Console.WriteLine("Upper-case: " + string.Join(", ", uppercase));
        }
    }
}