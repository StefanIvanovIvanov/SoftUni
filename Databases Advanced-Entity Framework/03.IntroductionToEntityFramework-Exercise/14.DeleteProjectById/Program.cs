using System;
using System.Linq;
using P02_DatabaseFirst.Data.Models;

namespace _14.DeleteProjectById
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new SoftUniContext())
            {
                var project2 = context.Projects.Where(e => e.ProjectId == 2).SingleOrDefault();

                var empProjects = context.EmployeesProjects.Where(ep => ep.ProjectId == 2);

                context.EmployeesProjects.RemoveRange(empProjects);
                context.Projects.Remove(project2);

                context.SaveChanges();

                var updatedProjects = context.Projects.Take(10).ToList();

                foreach (var pr in updatedProjects)
                {
                    Console.WriteLine(pr.Name);
                }
            }
        }
    }
}
