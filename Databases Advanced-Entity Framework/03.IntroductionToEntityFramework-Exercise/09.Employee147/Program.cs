using System;
using System.Linq;
using P02_DatabaseFirst.Data.Models;

namespace _09.Employee147
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new SoftUniContext())
            {
                var employee = context.Employees
                    .Where(e => e.EmployeeId == 147)
                    .Select(e => new
                    {
                        Name = $"{e.FirstName} {e.LastName}",
                        e.JobTitle,
                        Projects = e.EmployeesProjects.Select(ep => new { ep.Project.Name })
                    })
                    .SingleOrDefault();

                Console.WriteLine($"{employee.Name} - {employee.JobTitle}");
                foreach (var pr in employee.Projects.OrderBy(p => p.Name))
                {
                    Console.WriteLine(pr.Name);
                }

            }
        }
    }
}
