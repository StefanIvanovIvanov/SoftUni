using System;
using System.Linq;
using P02_DatabaseFirst.Data.Models;

namespace _05.EmployeesFromResearchAndDevelopment
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new SoftUniContext())
            {
                var emps = context.Employees
                    .Where(e => e.Department.Name == "Research and Development")
                    .OrderBy(e => e.Salary)
                    .ThenByDescending(e => e.FirstName)
                    .Select(e => new { e.FirstName, e.LastName, DepartmentName = e.Department.Name, e.Salary })
                    .ToList();

                foreach (var em in emps)
                {
                    Console.WriteLine($"{em.FirstName} {em.LastName} from {em.DepartmentName} - ${em.Salary:f2}");
                }
            }
        }
    }
}
