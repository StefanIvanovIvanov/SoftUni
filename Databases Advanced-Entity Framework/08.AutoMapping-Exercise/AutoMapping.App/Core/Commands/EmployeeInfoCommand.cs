using System;
using System.Collections.Generic;
using System.Text;
using AutoMapping.App.Core.Contracts;

namespace AutoMapping.App.Core.Commands
{
    public class EmployeeInfoCommand : ICommand
    {
        private readonly IEmployeeController employeeController;

        public EmployeeInfoCommand(IEmployeeController employeeController)
        {
            this.employeeController = employeeController;
        }

        public string Execute(string[] args)
        {
            int id = int.Parse(args[0]);

            var employeeDto = this.employeeController.GetEmployeeInfo(id);

            return
                $"ID: {employeeDto.EmployeeDtoId} - {employeeDto.FirstName} {employeeDto.LastName} - {employeeDto.Salary:F2}";
        }
    }
}
