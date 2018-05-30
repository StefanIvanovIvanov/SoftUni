using System;

namespace _04.Hotel
{
    class Program
    {
        static void Main(string[] args)
        {
            var month = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());
            double studioPricePerNight = 0;
            double doublePricePerNight = 0;
            double suitePricePerNight = 0;

            double discountStudio = 0;
            double discountDouble = 0;
            double discountSuite = 0;

            double discount = 0;

            if (month == "May" || month == "October")
            {
                 studioPricePerNight = 50;
                 doublePricePerNight = 65;
                 suitePricePerNight = 75;
            }
            else if (month == "June" || month == "September")
            {
                studioPricePerNight = 60;
                doublePricePerNight = 72;
                suitePricePerNight = 82;
            }
            else if (month == "July" || month == "August" || month == "December")
            {
                studioPricePerNight = 68;
                doublePricePerNight = 77;
                suitePricePerNight = 89;
            }

            double studioPriceTotal = studioPricePerNight * nights;
            double doublePriceTotal = doublePricePerNight * nights;
            double suitePriceTotal = suitePricePerNight * nights;

            if ((7 < nights && month == "September") || (7 < nights && month == "October"))
            {
                studioPriceTotal = studioPriceTotal - studioPricePerNight;
            }
            if ((7<nights && month == "May") || (7<nights && month == "October"))
            {
                discount = 0.05;
                discountStudio = studioPriceTotal * discount;
                studioPriceTotal = studioPriceTotal - discountStudio;
            }
            if ((14 < nights && month == "June") || (14 < nights && month == "September"))
            {
                discount = 0.10;
                discountDouble = doublePriceTotal * discount;
                doublePriceTotal = doublePriceTotal - discountDouble;
            }
            if ((14 < nights && month == "July") || (14 < nights && month == "August") || (14 < nights && month == "December"))
            {
                discount = 0.15;
                discountSuite = suitePriceTotal * discount;
                suitePriceTotal = suitePriceTotal - discountSuite;
            }

            Console.WriteLine($"Studio: {studioPriceTotal:f2} lv.");
            Console.WriteLine($"Double: {doublePriceTotal:f2} lv.");
            Console.WriteLine($"Suite: {suitePriceTotal:f2} lv.");

        }
    }
}