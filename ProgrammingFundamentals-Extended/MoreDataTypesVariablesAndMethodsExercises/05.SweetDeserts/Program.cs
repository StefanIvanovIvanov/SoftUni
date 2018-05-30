using System;

namespace _05.SweetDeserts
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal cash = decimal.Parse(Console.ReadLine());
            int guests = int.Parse(Console.ReadLine());
            double bananas = double.Parse(Console.ReadLine());
            double eggs = double.Parse(Console.ReadLine());
            double berries = double.Parse(Console.ReadLine());

            decimal portionsNeeded = 0;
            if (guests % 6 == 0)
            {
                portionsNeeded= guests / 6;
            }
            else
            {
                portionsNeeded = guests / 6 + 1;
            }
            decimal pricePerSixPortions = (decimal) (2 * bananas + 4 * eggs + 0.2 * berries);
            decimal totalPrice = portionsNeeded * pricePerSixPortions;
            if (cash >= totalPrice)
            {
                Console.WriteLine($"Ivancho has enough money - it would cost {totalPrice:f2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivancho will have to withdraw money - he will need {totalPrice-cash:f2}lv more.");
            }
        }
    }
}