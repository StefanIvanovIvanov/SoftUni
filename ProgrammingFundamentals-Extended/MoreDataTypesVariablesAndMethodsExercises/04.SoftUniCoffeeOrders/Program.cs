using System;
using System.Globalization;

namespace _04.SoftUniCoffeeOrders
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            decimal sum = 0;
            for (int i = 0; i < n; i++)
            {
                decimal pricePerCapsule = decimal.Parse(Console.ReadLine());
                string dateInput = Console.ReadLine();
                DateTime date = DateTime.ParseExact(dateInput, "d/M/yyyy", CultureInfo.InvariantCulture);
                int daysInMonth = DateTime.DaysInMonth(date.Year, date.Month);
                decimal capsulesCount = decimal.Parse(Console.ReadLine());
                decimal price = (decimal)((daysInMonth * capsulesCount) * pricePerCapsule);
                //Also Convert.ToDecimal(((daysInMonth * capsulesCount) * pricePerCapsule));
                sum += price;
                Console.WriteLine($"The price for the coffee is: ${price:f2}");
            }
            Console.WriteLine($"Total: ${sum:f2}");
        }
    }
}