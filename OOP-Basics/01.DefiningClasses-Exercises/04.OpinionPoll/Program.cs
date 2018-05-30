using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.OpinionPoll
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Family family=new Family();
            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                string name = tokens[0];
                int age = int.Parse(tokens[1]);

                Person person = new Person(age, name);
                family.AddMember(person);
            }
            List<Person> sorted = family.FilterAge(family.People);
            foreach (Person person in sorted.OrderBy(x=>x.Name))
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}
