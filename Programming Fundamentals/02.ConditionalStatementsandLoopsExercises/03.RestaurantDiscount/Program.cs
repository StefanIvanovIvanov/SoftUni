using System;

namespace _03.RestaurantDiscount
{
    class Program
    {
        static void Main(string[] args)
        {
            int groupSize = int.Parse(Console.ReadLine());
            string package = Console.ReadLine();

            string hall = null;
            double price = 0;
            double discount = 0;

            if (groupSize <= 50)
            {
                hall = "Small Hall";
                price = 2500;
            }
            else if (50 < groupSize && groupSize <= 100)
            {
                hall = "Terrace";
                price = 5000;
            }
            else if (100 < groupSize && groupSize <= 120)
            {
                hall = "Great Hall";
                price = 7500;
            }
            else
            {
                Console.WriteLine("We do not have an appropriate hall.");
                return;
            }

            if (package == "Normal")
            {
                price = price + 500;
                discount = price * 0.05;
                price = price - discount;
            }
            else if (package == "Gold")
            {
                price = price + 750;
                discount = price * 0.10;
                price = price - discount;
            }
            else if (package == "Platinum")
            {
                price = price + 1000;
                discount = price * 0.15;
                price = price - discount;
            }
            price = price / groupSize;

            Console.WriteLine($"We can offer you the {hall}");
            Console.WriteLine($"The price per person is {price:f2}$");
        }
    }
}