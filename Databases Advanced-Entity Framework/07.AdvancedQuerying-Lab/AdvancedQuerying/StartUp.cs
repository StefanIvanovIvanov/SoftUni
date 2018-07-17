using System;
using System.ComponentModel;
using System.Linq;
using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Z.EntityFramework.Plus;

namespace AdvancedQuerying
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Context context = new Context();

            string querry = "SELECT * FROM Employees";

            var result = context.Employees.FromSql(querry).ToArray();

            string querryJobTitle = "SELECT * FROM Employees WHERE JobTitle = {0}";

            var resultJobTtle = context.Employees.FromSql(querryJobTitle, "Software Engineer").ToArray();

             resultJobTtle = context.Employees.FromSql(querry).Where(e=>e.JobTitle=="Software Engineer").ToArray();

            var employee = context.Employees.FirstOrDefault();

            var entry = context.Entry(employee);

            entry.State = EntityState.Added;

            entry.State = EntityState.Deleted;

            entry.State = EntityState.Detached;

            entry.State = EntityState.Modified;

            entry.State = EntityState.Unchanged;

            //Install-Package Z.EntityFramework.Plus.EFCore

            context.Employees.Where(u => u.FirstName == "Pesho").Delete();

            context.Employees
                .Where(t => t.FirstName == "Pesho")
                .Update(u => new Employee() { FirstName = "Plamen" });


            IQueryable<Employee> employees = context.Employees
                .Where(e => e.FirstName == "Plamen");

            employees.Update(e => new Employee() { Age = 99 });

            
            //Lazy Loading
           //Install-Package Microsoft.EntityFrameworkCore.Proxies
        }
    }
}
