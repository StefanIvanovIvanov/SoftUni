using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SoftUniAirline
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal n = decimal.Parse(Console.ReadLine());
            List<decimal> totalProfit=new List<decimal>();
            for (decimal i = 0; i < n; i++)
            {
                decimal adultPassengerCount = decimal.Parse(Console.ReadLine());
                decimal adultTicketPrice = decimal.Parse(Console.ReadLine());
                decimal youthPassengersCount = decimal.Parse(Console.ReadLine());
                decimal youthTicketPrice = decimal.Parse(Console.ReadLine());
                decimal fuelPricePerHour = decimal.Parse(Console.ReadLine());
                decimal fuelConsumptionPerHour = decimal.Parse(Console.ReadLine());
                decimal flightDuration = decimal.Parse(Console.ReadLine());
                decimal income = adultPassengerCount * adultTicketPrice + youthPassengersCount * youthTicketPrice;
                decimal expenses = flightDuration * fuelConsumptionPerHour * fuelPricePerHour;
                decimal result = income - expenses;
                totalProfit.Add(result);
                if (result > 0)
                {
                    Console.WriteLine($"You are ahead with {result:f3}$.");
                }
                else
                {
                    Console.WriteLine($"We've got to sell more tickets! We've lost {result:f3}$.");
                }
            }
            Console.WriteLine($"Overall profit -> {totalProfit.Sum():f3}$.");
            Console.WriteLine($"Average profit -> {totalProfit.Average():f3}$.");
        }
    }
}