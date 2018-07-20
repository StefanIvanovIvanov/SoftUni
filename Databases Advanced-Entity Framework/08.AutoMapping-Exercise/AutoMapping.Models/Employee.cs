using System;
using System.ComponentModel.DataAnnotations;

namespace AutoMapping.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public decimal Salary { get; set; }

        public DateTime Birthday { get; set; }

        public string Adress { get; set; }
    }
}
