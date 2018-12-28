using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.SearchForANumber
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();

            string[] commands = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();


            int take = int.Parse(commands[0]);
            int delete = int.Parse(commands[1]);
            int check = int.Parse(commands[2]);

            List<int> newList = new List<int>();
            //take
            for (int i = 0; i < take; i++)
            {
                newList.Add(numbers[i]);
            }
            //delete
            for (int i = 0; i < delete; i++)
            {
                newList.RemoveAt(0);
            }
            //check and print
            if (newList.Contains(check))
            {
                Console.WriteLine("YES!");
            }
            else
            {
                Console.WriteLine("NO!");
            }
        }
    }
}