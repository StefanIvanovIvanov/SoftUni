using AutoMapping.App.Core.DTOs;

namespace Employees.DtoModels
{
    public class EmployeeManagerDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Salary { get; set; }

        public ManagerDto Manager { get; set; }
    }
}
