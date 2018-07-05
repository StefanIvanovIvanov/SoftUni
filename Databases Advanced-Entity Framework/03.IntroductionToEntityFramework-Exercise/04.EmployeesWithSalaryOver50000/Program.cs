using System;
using System.Linq;
using P02_DatabaseFirst.Data.Models;

namespace _04.EmployeesWithSalaryOver50000
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SoftUniContext context = new SoftUniContext())
            {
                var employees = context.Employees
                    .Where(e => e.Salary >= 50000)
                    .Select(e => e.FirstName)
                    .OrderBy(e => e).ToArray();

                foreach (var e in employees)
                {
                    Console.WriteLine(e);
                }
            }         
        }
    }
}
