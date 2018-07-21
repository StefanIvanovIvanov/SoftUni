using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapping.App.Core.Contracts;

namespace AutoMapping.App.Core.Commands
{
   public class ListEmployeesOlderThan:ICommand
   {
       private readonly IEmployeeController employeeController;

        public ListEmployeesOlderThan(IEmployeeController employeeController)
        {
            this.employeeController = employeeController;
        }

        public string Execute(string[] args)
        {
            int age = int.Parse(args[0]);

            var employees = employeeController.OlderThanAge(age);

            if (employees == null)
            {
                throw new ArgumentException($"No employees older than {age} years.");
            }

            var result = new StringBuilder();

            foreach (var emp in employees.OrderByDescending(e => e.Salary))
            {
                result.Append($"{emp.FirstName} {emp.LastName} - ${emp.Salary:F2} - Manager: ");

                if (emp.Manager == null)
                {
                    result.Append("[no manager]");
                }
                else
                {
                    result.Append(emp.Manager.LastName);
                }
                result.AppendLine();
            }

            return result.ToString().TrimEnd();
        }
    }
}
