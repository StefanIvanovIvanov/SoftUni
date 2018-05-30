using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02.ExtendedDatabase
{

    public class Database
    {
        private List<Person> peopleList;

        public Database()
        {
            this.peopleList = new List<Person>();
        }

        public Database(List<Person> people)
            : this()
        {
            if (people != null)
            {
                foreach (var person in people)
                {
                    this.Add(person);
                }
            }
        }

        public int Count => this.peopleList.Count;

        public void Add(Person person)
        {
            if (this.peopleList.Any(p => p.Id == person.Id || p.UserName == person.UserName))
            {
                throw new InvalidOperationException();
            }

            this.peopleList.Add(person);
        }

        public void Remove(Person person)
        {
            Person personToRemove = this.peopleList.FirstOrDefault(p => p.Id == person.Id && p.UserName == person.UserName);
            this.peopleList.Remove(personToRemove);

        }

        public Person Find(long id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            var foundPerson = this.peopleList.FirstOrDefault(p => p.Id == id);
            if (foundPerson == null)
            {
                throw new InvalidOperationException();
            }

            return foundPerson;
        }

        public Person Find(string username)
        {
            if (username == null)
            {
                throw new ArgumentNullException();
            }

            var foundPerson = this.peopleList.FirstOrDefault(p => p.UserName == username);
            if (foundPerson == null)
            {
                throw new InvalidOperationException();
            }

            return foundPerson;
        }

    }
}
