using System;
using System.Collections.Generic;
using System.Linq;
using IntroductionToEntityFramework.Data;
using Microsoft.EntityFrameworkCore;
using Remotion.Linq.Clauses;

namespace IntroductionToEntityFramework
{
    class StartUp
    {
        static void Main(string[] args)
        {

            //Install - Package Microsoft.EntityFrameworkCore.Tools
            //Install - Package Microsoft.EntityFrameworkCore.SqlServer
            //Install - Package Microsoft.EntityFrameworkCore.SqlServer.Design

            /*
             •	First, the name of the command:
             Scaffold - DbContext

                 •	Second, the connection we will be using (our connection string):
             -Connection "Server=<ServerName>;Database=<DatabaseName>;Integrated Security=True;"
             For ServerName, use the name of your local MS SQL Server instance or ".".
                 For DatabaseName, use the name of the database you want to use, in this case – SoftUni.

            •	Third, we need to declare our service provider, we’ll be using Microsoft.EntityFrameworkCore.SqlServer:
             -Provider Microsoft.EntityFrameworkCore.SqlServer

            •	And the fourth thing we’ll do, is to give it a directory where all of our models will go(e.g.Models):
             -OutputDir Data / Models

              Our final command will look like this:
  Scaffold-DbContext -Connection "Server=.;Database=SoftUni;Integrated Security=True;" -Provider Microsoft.EntityFrameworkCore.SqlServer -OutputDir Data/Models

             */

            // Scaffold - DbContext - Connection "Server=.;Database=SoftUni;Integrated Security=True;" - Provider Microsoft.EntityFrameworkCore.SqlServer - OutputDir Data


            //To Clear the packages:
            //Uninstall - Package Microsoft.EntityFrameworkCore.Tools - RemoveDependencies
            //Uninstall - Package Microsoft.EntityFrameworkCore.SqlServer.Design - RemoveDependencies

            var context = new SoftUniContext();

            var employee = context.Employees.FirstOrDefault(e => e.FirstName == "Peter");
            Console.WriteLine(employee.FirstName+" "+employee.LastName);

            var newTown = new Towns()
            {
                Name = "Sliven 007",
                Addresses = new List<Addresses>()
                {
                    new Addresses() {AddressText = "Hadji Dimitar"},
                    new Addresses() {AddressText = "Vasil Levski"}
                }
            };
            context.Towns.Add(newTown);

            var town = context.Towns.Include(t => t.Addresses).FirstOrDefault(t => t.Name == "Sliven 007");
            Console.WriteLine(string.Join(", ", town.Addresses.Select(a=>a.AddressText)));

            //context.SaveChanges();
        }
    }
}
