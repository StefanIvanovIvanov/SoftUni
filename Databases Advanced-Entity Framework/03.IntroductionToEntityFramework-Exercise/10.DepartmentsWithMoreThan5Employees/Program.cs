using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using P02_DatabaseFirst.Data.Models;

namespace _10.DepartmentsWithMoreThan5Employees
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SoftUniContext context = new SoftUniContext())
            {
                var departmentSeparator = $"{Environment.NewLine}{new string('-', 10)}{Environment.NewLine}";

                Console.WriteLine(string.Join(departmentSeparator, context.Departments
                    .Where(d => d.Employees.Count > 5)
                    .OrderBy(d => d.Employees.Count)
                    .ThenBy(d => d.Name)
                    .Select(d => $"{d.Name} - {d.Manager.FirstName} {d.Manager.LastName}{Environment.NewLine}" +
                                 $@"{string.Join(Environment.NewLine, d.Employees
                                     .OrderBy(e => e.FirstName)
                                     .ThenBy(e => e.LastName)
                                     .Select(e => $"{e.FirstName} {e.LastName} - {e.JobTitle}"))}")));

                Console.WriteLine(new string('-', 10));
            }
        }
    }
}
