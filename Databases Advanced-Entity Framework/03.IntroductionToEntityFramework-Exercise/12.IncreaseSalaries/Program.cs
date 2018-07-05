using System;
using System.Linq;
using P02_DatabaseFirst.Data.Models;

namespace _12.IncreaseSalaries
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new SoftUniContext())
            {
                var selectedEmps = context.Employees.Where(e => e.Department.Name == "Engineering"
                                                           || e.Department.Name == "Tool Design"
                                                           || e.Department.Name == "Marketing "
                                                           || e.Department.Name == "Information Services")
                    .ToList();

                foreach (var emp in selectedEmps)
                {
                    emp.Salary *= 1.12m;
                }

                context.SaveChanges();

                var output = selectedEmps
                    .OrderBy(e => e.FirstName)
                    .ThenBy(e => e.LastName);

                foreach (var emp in output)
                {
                    Console.WriteLine($"{emp.FirstName} {emp.LastName} (${emp.Salary:f2})");
                }
            }
        }
    }
}
