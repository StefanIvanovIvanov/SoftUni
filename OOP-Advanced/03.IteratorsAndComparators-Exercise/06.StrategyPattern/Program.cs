using System;
using System.Collections.Generic;

namespace _06.StrategyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedSet<Person> sortedByName = new SortedSet<Person>(new PersonNameComparer());
            SortedSet<Person> sortedByAge = new SortedSet<Person>(new PersonAgeComparer());

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] personArgs = Console.ReadLine().Split();
                string name = personArgs[0];
                int age = int.Parse(personArgs[1]);
                Person person = new Person(name, age);
                sortedByName.Add(person);
                sortedByAge.Add(person);
            }

            foreach (Person person in sortedByName)
            {
                Console.WriteLine(person);
            }

            foreach (Person person in sortedByAge)
            {
                Console.WriteLine(person);
            }
        }
    }
}
