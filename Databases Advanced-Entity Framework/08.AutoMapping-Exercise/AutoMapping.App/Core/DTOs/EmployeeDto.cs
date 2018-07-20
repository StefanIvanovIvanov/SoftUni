using System;
using System.Collections.Generic;
using System.Text;

namespace AutoMapping.App.Core.DTOs
{
    public class EmployeeDto
    {
        public int EmployeeDtoId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Salary { get; set; }
    }
}
