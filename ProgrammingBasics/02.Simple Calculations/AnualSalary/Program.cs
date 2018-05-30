using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnualSalary
{
    class Program
    {
        static void Main(string[] args)
        {
            double N = double.Parse(Console.ReadLine());
            double M = double.Parse(Console.ReadLine());
            double Cur = double.Parse(Console.ReadLine());

            double monthlySalary = M * N;
            double bonus = monthlySalary * 2.5;
            double anualSalary = (monthlySalary * 12) + bonus;
            double taxes = anualSalary * 0.25;
            double finalSalary = anualSalary - taxes;
            double leva = finalSalary * Cur;
            double perDay = leva / 365;
            Console.WriteLine(perDay.ToString("F"));

        }
    }
}
