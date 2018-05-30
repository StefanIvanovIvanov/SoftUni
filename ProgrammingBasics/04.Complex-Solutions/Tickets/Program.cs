using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            var cat = Console.ReadLine();
            var people = double.Parse(Console.ReadLine());

            double transport = 0;
            double totalTicketPrice = 0;

            if (1 <= people && people <= 4)
            { transport = budget * 0.75; }
            else if (5 <= people && people <= 9)
            { transport = budget * 0.60; }
            else if (10 <= people && people <= 24)
            { transport = budget * 0.50; }
            else if (25 <= people && people <= 49)
            { transport = budget * 0.40; }
            else if (people >= 50)
            { transport = budget * 0.25; }

            double remBudget = budget - transport;

            if (cat == "VIP")
            {
                totalTicketPrice = people * 499.99;
            }
            else if (cat == "Normal")
            {
                totalTicketPrice = people * 249.99;
            }

            double result = remBudget - totalTicketPrice;
            double resultNotEnough = Math.Abs(totalTicketPrice - remBudget);



            if (result>=0)
            {
                Console.WriteLine($"Yes! You have {result:f2} leva left.");
            }
            else if ( result<0)
            {
                Console.WriteLine($"Not enough money! You need {resultNotEnough:f2} leva.");
            }
        }
    }
}
