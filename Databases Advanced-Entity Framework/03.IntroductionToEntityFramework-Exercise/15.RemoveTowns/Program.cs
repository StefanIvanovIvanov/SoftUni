using System;
using System.Linq;
using P02_DatabaseFirst.Data.Models;

namespace _15.RemoveTowns
{
    class Program
    {
        static void Main(string[] args)
        {
            string town = Console.ReadLine();

            using (var context = new SoftUniContext())
            {
                var townToDelete = context.Towns.Where(t => t.Name == town).SingleOrDefault();

                var addresses = context.Addresses.Where(a => a.TownId == townToDelete.TownId).ToList();

                foreach (var address in addresses)
                {
                    var addressEmps = context.Employees
                        .Where(e => e.AddressId == address.AddressId)
                        .ToList();

                    foreach (var emp in addressEmps)
                    {
                        emp.AddressId = null;
                    }
                }

                context.Addresses.RemoveRange(addresses);
                context.Towns.Remove(townToDelete);
                context.SaveChanges();
            }
        }
    }
}
