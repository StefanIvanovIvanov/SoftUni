using System;

namespace CarToGo
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            var season = Console.ReadLine();
            double price = 0;
            string car = null;
            string klas = null;

            if (budget <= 100)
            {
                klas = "Economy class";
                if (season == "Summer")
                {
                    car = "Cabrio";
                    price = budget*0.35;
                }
                else if (season == "Winter")
                {
                    car = "Jeep";
                    price = budget * 0.65;
                }
            }

            else if (100< budget&&budget <= 500)
            {
                klas = "Compact class";
                if (season == "Summer")
                {
                    car = "Cabrio";
                    price = budget * 0.45;
                }
                else if (season == "Winter")
                {
                    car = "Jeep";
                    price = budget * 0.80;
                }
            }

            else if (500< budget)
            {
                klas = "Luxury class";
                car = "Jeep";
                price = budget * 0.90;
            }
            Console.WriteLine(klas);
            Console.WriteLine("{0} - {1:f2}", car, price);
        }
    }
}