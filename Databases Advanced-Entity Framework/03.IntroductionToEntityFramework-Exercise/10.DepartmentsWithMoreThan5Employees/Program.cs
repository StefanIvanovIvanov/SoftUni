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
                var departments = context.Departments
                    .Where(d => d.Employees.Count() > 5)
                    .Select(d => new
                    {
                        EmpCount = d.Employees.Count(),
                        DepartmentName = d.Name,
                        ManagerId = d.ManagerId,
                        ManagerName = $"{d.Manager.FirstName} {d.Manager.LastName}",
                        Employees = d.Employees.Select(e => new
                        {
                            FirstName = e.FirstName,
                            LastName = e.LastName,
                            e.JobTitle,
                        })

                    })
                    .OrderBy(dep => dep.EmpCount)
                    .ThenBy(dep => dep.DepartmentName)
                    .ToList();

                foreach (var de in departments)
                {
                    Console.WriteLine($"{de.DepartmentName} - {de.ManagerName}");

                    var sorted = de.Employees.OrderBy(e => e.FirstName).ThenBy(e => e.LastName).ToList();

                    foreach (var emp in sorted)
                    {
                        Console.WriteLine($"{emp.FirstName} {emp.LastName} - {emp.JobTitle}");
                    }
                    Console.WriteLine("----------");
                }
            }
        }
    }
}
