using System;
using System.Linq;
using P02_DatabaseFirst.Data.Models;

namespace _08.AddressesByTown
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SoftUniContext context = new SoftUniContext())
            {
                var addresses = context.Addresses
                    .OrderByDescending(x => x.Employees.Count)
                    .ThenBy(x => x.Town.Name)
                    .ThenBy(x => x.AddressText)
                    .Select(x => new
                    {
                        AddressText = x.AddressText,
                        TownName = x.Town.Name,
                        Count = x.Employees.Count
                    })
                    .Take(10)
                    .ToArray();

                foreach (var a in addresses)
                {
                    Console.WriteLine($"{a.AddressText}, {a.TownName} - {a.Count} employees");
                }
            }
        }
    }
}
