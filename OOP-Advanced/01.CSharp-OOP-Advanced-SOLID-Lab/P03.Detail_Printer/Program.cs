using System;
using System.Collections.Generic;

namespace P03.DetailPrinter
{
    class Program
    {
        static void Main()
        {
            Employee employee = new Employee("employeeName");
            List<string> documents = new List<string>();
            Manager manager = new Manager("managerName", documents);
            List<Employee> employees = new List<Employee>();
            employees.Add(employee);
            employees.Add(manager);

            DetailsPrinter detailsPrinter = new DetailsPrinter(employees);
            detailsPrinter.PrintDetails();
        }
    }
}
