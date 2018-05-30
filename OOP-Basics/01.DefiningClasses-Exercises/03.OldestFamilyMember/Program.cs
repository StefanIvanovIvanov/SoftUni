using System;
using System.Net.Sockets;

namespace _03.OldestFamilyMember
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Family family = new Family();
            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                string name = tokens[0];
                int age = int.Parse(tokens[1]);

                Person person=new Person();
                person.Name = name;
                person.Age = age;

                family.AddMember(person);
            }
            Person oldestPerson = family.GetOldestMember(family.People);
            Console.WriteLine($"{oldestPerson.Name} {oldestPerson.Age}");
        }
    }
}
