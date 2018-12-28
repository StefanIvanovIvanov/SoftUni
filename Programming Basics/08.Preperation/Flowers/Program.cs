using System;

namespace Flowers
{
    class Program
    {
        static void Main(string[] args)
        {
            double chrysanthemum = int.Parse(Console.ReadLine());
            double roses = int.Parse(Console.ReadLine());
            double tulips = int.Parse(Console.ReadLine());
            var season = Console.ReadLine();
            var holiday = Console.ReadLine();

            double priceChrysanthemum = 0;
            double priceRoses = 0;
            double priceTulips = 0;

            if (season == "Spring" || season == "Summer")
            {
                priceChrysanthemum = 2.00;
                priceRoses = 4.10;
                priceTulips = 2.50;
            }
            else if (season == "Autumn" || season == "Winter")
            {
                 priceChrysanthemum = 3.75;
                 priceRoses = 4.50;
                 priceTulips = 4.15;
            }

            if (holiday == "Y")
            {
                priceChrysanthemum = priceChrysanthemum+(priceChrysanthemum*0.15);
                priceRoses = priceRoses + (priceRoses * 0.15);
                priceTulips = priceTulips + (priceTulips * 0.15);
            }

            double totalPriceChrysanthemum = priceChrysanthemum * chrysanthemum;
            double totalPriceRoses = priceRoses* roses;
            double totalPriceTulips = priceTulips* tulips;
            double totalPrice = totalPriceChrysanthemum + totalPriceRoses + totalPriceTulips;

            if (tulips > 7&& season == "Spring")
            {
                totalPrice = totalPrice - (totalPrice * 0.05);
            }
            if (roses >= 10 && season == "Winter")
            {
                totalPrice = totalPrice - (totalPrice * 0.10);
            }
            if (chrysanthemum + roses + tulips > 20)
            {
                totalPrice = totalPrice - (totalPrice * 0.20);
            }
            Console.WriteLine("{0:f2}", totalPrice+2);
        }
    }
}