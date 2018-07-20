using System;
using System.Collections.Generic;
using System.Text;
using AutoMapping.App.Core.Contracts;
using AutoMapping.App.Core.DTOs;

namespace AutoMapping.App.Core.Commands
{
    public class AddEmployeeCommand:ICommand
    {
        private readonly IEmployeeController employeeeController;

        public AddEmployeeCommand(IEmployeeController employeeeController)
        {
            this.employeeeController = employeeeController;
        }

        public string Execute(string[] args)
        {
            string firstName = args[0];
            string lastName = args[1];
            decimal salary = decimal.Parse(args[2]);

            EmployeeDto emplployeeDto = new EmployeeDto
            {
                FirstName = firstName,
                LastName = lastName,
                Salary = salary
            };

            this.employeeeController.AddEmployee(emplployeeDto);

            return $"Employee {firstName} {lastName} was added successfully";
        }
    }
}
