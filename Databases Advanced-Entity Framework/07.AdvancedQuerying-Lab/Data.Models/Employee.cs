using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
        [ConcurrencyCheck]
        public int? Age { get; set; }
        public virtual ICollection<Project> ManagerOfProjects { get; set; }
    }
}
