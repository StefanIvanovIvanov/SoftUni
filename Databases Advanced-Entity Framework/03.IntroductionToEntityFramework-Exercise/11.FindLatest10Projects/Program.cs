using System;
using System.Globalization;
using System.Linq;
using P02_DatabaseFirst.Data.Models;

namespace _11.FindLatest10Projects
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var context = new SoftUniContext())
            {
                var projects = context.Projects
                    .OrderByDescending(p => p.StartDate)
                    .Take(10)
                    .OrderBy(p => p.Name)
                    .Select(p => new
                    {
                        p.Name,
                        p.Description,
                        StartDate = p.StartDate
                            .ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
                    })
                    .ToList();

                foreach (var pr in projects)
                {
                    Console.WriteLine(pr.Name);
                    Console.WriteLine(pr.Description);
                    Console.WriteLine(pr.StartDate);
                }
            }
        }
    }
}
