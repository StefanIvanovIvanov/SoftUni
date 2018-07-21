using System;
using System.Collections.Generic;
using System.Text;

namespace AutoMapping.App.Core.DTOs
{
   public class ManagerDto
    {
        public ManagerDto()
        {
            this.EmployeeDto=new HashSet<EmployeeDto>();
        }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int EmployeesCount => EmployeeDto.Count;

        public ICollection<EmployeeDto> EmployeeDto { get; set; }
    }
}
