using System;
using System.Globalization;
using System.Linq;
using P02_DatabaseFirst.Data.Models;

namespace _07.EmployeesAndProjects
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SoftUniContext context = new SoftUniContext())
            {
                var employees = context.Employees
                    .Where(x => x.EmployeesProjects.Any(s => s.Project.StartDate.Year >= 2001 &&
                                                             s.Project.StartDate.Year <= 2003))
                    .Select(x => new
                    {
                        EmployeeName = x.FirstName + " " + x.LastName,
                        ManagerName = x.Manager.FirstName + " " + x.Manager.LastName,
                        Projects = x.EmployeesProjects.Select(s => new
                        {
                            ProjectName = s.Project.Name,
                            StartDate = s.Project.StartDate,
                            EndDate = s.Project.EndDate
                        }).ToArray()
                    })
                    .Take(30).ToArray();

                foreach (var e in employees)
                {
                    Console.WriteLine($"{e.EmployeeName} - Manager: {e.ManagerName}");

                    foreach (var p in e.Projects)
                    {
                        Console.WriteLine($"--{p.ProjectName} - {p.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)} - {p.EndDate?.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture) ?? "not finished"}");
                    }
                }
            }
        }
    }
}
