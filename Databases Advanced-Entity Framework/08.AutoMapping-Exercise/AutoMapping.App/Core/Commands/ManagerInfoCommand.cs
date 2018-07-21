using System;
using System.Collections.Generic;
using System.Text;
using AutoMapping.App.Core.Contracts;

namespace AutoMapping.App.Core.Commands
{
  public  class ManagerInfoCommand:ICommand
  {
      private readonly IManagerController managerController;

        public ManagerInfoCommand(IManagerController managerController)
        {
            this.managerController = managerController;
        }

        public string Execute(string[] args)
        {
            StringBuilder sb = new StringBuilder();

            int employeeId = int.Parse(args[0]);

            var managerDto = this.managerController.GetManagerInfo(employeeId);

            sb.AppendLine($"{managerDto.FirstName} {managerDto.LastName} | Employees: {managerDto.EmployeesCount}");

            foreach (var employee in managerDto.EmployeeDto)
            {
                sb.AppendLine($"    -{employee.FirstName} {employee.LastName} - ${employee.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
