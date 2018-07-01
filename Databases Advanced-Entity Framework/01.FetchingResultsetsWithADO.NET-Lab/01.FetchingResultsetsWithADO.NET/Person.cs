using System;
using System.Collections.Generic;
using System.Text;

namespace _01.FetchingResultsetsWithADO.NET
{
    abstract class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        protected Person(string firstname, string lastName)
        {
            this.FirstName = firstname;
            this.LastName = lastName;
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName}";
        }
    }
}
