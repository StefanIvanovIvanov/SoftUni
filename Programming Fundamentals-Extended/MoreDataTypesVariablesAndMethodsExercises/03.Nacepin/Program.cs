using System;

namespace _03.Nacepin
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceUS = double.Parse(Console.ReadLine());
            double weightUS = double.Parse(Console.ReadLine());
            double priceUK = double.Parse(Console.ReadLine());
            double weightUK = double.Parse(Console.ReadLine());
            double priceCH = double.Parse(Console.ReadLine());
            double weightCH = double.Parse(Console.ReadLine());


            double usPriceInBg = priceUS / 0.58;
            double ukPriceInBg = priceUK / 0.41;
            double chPriceInBg = priceCH * 0.27;



            double pricePerKgUs =   usPriceInBg/ weightUS;
            double pricePerKgUk =    ukPriceInBg/ weightUK;
            double pricePerKgCh =  chPriceInBg/ weightCH;

            double cheapest = Math.Min(pricePerKgUs, Math.Min(pricePerKgUk, pricePerKgCh));
            double mostExpensive = Math.Max(pricePerKgUs, Math.Max(pricePerKgUk, pricePerKgCh));
            double difference = mostExpensive - cheapest;

            if (pricePerKgUs == cheapest)
            {
                Console.WriteLine($"US store. {cheapest:f2} lv/kg");
            }
            else if (pricePerKgUk == cheapest)
            {
                Console.WriteLine($"UK store. {cheapest:f2} lv/kg");
            }
            else if (pricePerKgCh == cheapest)
            {
                Console.WriteLine($"Chinese store. {cheapest:f2} lv/kg");
            }
            Console.WriteLine($"Difference {difference:f2} lv/kg");
        }
    }
}