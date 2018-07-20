using System;
using System.Collections.Generic;
using System.Text;

namespace AutoMapping.App.Core.DTOs
{
    public class EmployeePersonalInfoDto
    {
        public int EmployeeId { get; set; }
        
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Salary { get; set; }

        public DateTime Birthday { get; set; }

        public string Adress { get; set; }
    }
}
