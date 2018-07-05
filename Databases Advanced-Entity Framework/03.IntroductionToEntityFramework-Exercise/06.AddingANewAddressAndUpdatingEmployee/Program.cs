using System;
using System.Linq;
using P02_DatabaseFirst.Data.Models;

namespace _06.AddingANewAddressAndUpdatingEmployee
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SoftUniContext context = new SoftUniContext())
            {
                Address newAddress = new Address()
                {
                    AddressText = "Vitoshka 15",
                    TownId = 4
                };

                var nakov = context.Employees.FirstOrDefault(e => e.LastName == "Nakov");
                nakov.Address = newAddress;

                context.SaveChanges();
            
              var addresses = context.Employees
                  .OrderByDescending(x => x.AddressId)
                  .Select(x => x.Address.AddressText)
                  .Take(10)
                  .ToArray();
            
              foreach (var a in addresses)
              {
                  Console.WriteLine(a);
              }
            }
        }
    }
}
