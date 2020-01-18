using System;
using System.Collections.Generic;

namespace _05.ComparingObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> peopleList = new List<Person>();
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] commandArgs = input.Split();
                Person person = new Person(commandArgs[0], int.Parse(commandArgs[1]), commandArgs[2]);
                peopleList.Add(person);
            }

            int index = int.Parse(Console.ReadLine()) - 1;
            Person personToCompare = peopleList[index];
            int matches = 0;
            foreach (var p in peopleList)
            {
                if (p.CompareTo(personToCompare) == 0)
                {
                    matches++;
                }
            }
            if (matches > 1)
            {
                Console.WriteLine($"{matches} {peopleList.Count - matches} {peopleList.Count}");
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }
    }
}
