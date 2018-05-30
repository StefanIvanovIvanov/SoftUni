using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRoom
{
    class Program
    {
        static void Main(string[] args)
        {

            var month = Console.ReadLine();
            var nights = double.Parse(Console.ReadLine());

            double priceStudio = 0;
            double priceAparment = 0;
            double discountStudio = 0;
            double discountAparment = 0;

            if (month == "May" || month == "October")
            {
                priceStudio = priceStudio + 50;
                priceAparment = priceAparment + 65;
            }
            else if (month == "June" || month == "September")
            {
                priceStudio = priceStudio + 75.20;
                priceAparment = priceAparment + 68.70;
            }
            else if (month == "July" || month == "August")
            {
                priceStudio = priceStudio + 76;
                priceAparment = priceAparment + 77;
            }

            if ((7 < nights && nights < 14) && (month == "May" || month == "October"))
            {
                discountStudio = priceStudio * 0.05;
                priceStudio = priceStudio - discountStudio;
            }

            else if ((14 < nights) && (month == "May" || month == "October"))
            {
                discountStudio = priceStudio * 0.30;
                priceStudio = priceStudio - discountStudio;

                discountAparment = priceAparment * 0.10;
                priceAparment = priceAparment - discountAparment;
            }
            else if ((14 < nights) && (month == "June" || month == "September"))
            {
                discountStudio = priceStudio * 0.20;
                priceStudio = priceStudio - discountStudio;

                discountAparment = priceAparment * 0.10;
                priceAparment = priceAparment - discountAparment;
            }
            else if (14 < nights && (month != "May" && month != "October" && month != "June" && month != "September"))
            {
                discountAparment = priceAparment * 0.10;
                priceAparment = priceAparment - discountAparment;
            }

            double resultAparment = priceAparment * nights;
            double resultStudio = priceStudio * nights;

            Console.WriteLine($"Apartment: {resultAparment:f2} lv.");
            Console.WriteLine($"Studio: {resultStudio:f2} lv.");
        }
    }
}