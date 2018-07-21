using System;
using System.Collections.Generic;
using System.Text;
using AutoMapping.App.Core.Contracts;

namespace AutoMapping.App.Core.Commands
{
    public class EmployeePersonalInfoCommand:ICommand
    {
        private readonly IEmployeeController employeeController;

        public EmployeePersonalInfoCommand(IEmployeeController employeeController)
        {
            this.employeeController=employeeController;
            ;
        }

        public string Execute(string[] args)
        {
            int id = int.Parse(args[0]);
          
            var employeeDto = this.employeeController.GetEmployeePersonalInfoDto(id);

            return
                $"ID {employeeDto.EmployeeId} - {employeeDto.FirstName} {employeeDto.LastName} - ${employeeDto.Salary:F2}\n" +
                $"Birthday: {employeeDto.Birthday.ToString("dd-MM-yyyy")}\n" +
                $"Adress: {employeeDto.Adress}\n";
        }
    }
}
