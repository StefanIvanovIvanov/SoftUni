using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;

namespace _02.ChangeList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();

            List<string> command = Console.ReadLine().ToLower()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            List<int> result = new List<int>();
            //while start
            while (command[0] != "odd" && command[0] != "even")
            {
                if (command[0] == "delete")
                {
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        int deleteNumber = int.Parse(command[1]);
                        if (numbers[i] == deleteNumber)
                        {
                            numbers.Remove(deleteNumber);
                            i--;
                        }
                    }
                }
                if (command[0] == "insert")
                {
                    numbers.Insert(int.Parse(command[2]), int.Parse(command[1]));
                }
                //new command input
                command = Console.ReadLine().ToLower().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();
            }
            //while end

            //if off-even start
            if (command[0] == "odd")
            {
                foreach (int number in numbers)
                {
                    if (number % 2 != 0)
                    {
                        result.Add(number);
                    }
                }
            }
            if (command[0] == "even")
            {
                foreach (int number in numbers)
                {
                    if (number % 2 == 0)
                    {
                        result.Add(number);
                    }
                }
            }

            //printrestults
            Console.WriteLine(String.Join(" ", result));

        }
    }
}
