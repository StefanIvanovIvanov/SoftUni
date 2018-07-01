using System;
using System.Collections.Generic;
using System.Text;
using _01.FetchingResultsetsWithADO.NET;

namespace _01.FetchingResultsetsWithADO.NET
{
    class Employee:Person
    {
    public string JobTitle { get; set; }

        public Employee(string firstName, string lastName, string jobTitle)
            :base(firstName, lastName)
        {
            this.JobTitle = jobTitle;
        }

        public override string ToString()
        {
            return base.ToString() + $" -> {this.JobTitle}";
        }
    }
}
