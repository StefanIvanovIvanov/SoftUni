using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wine
{
    class Program
    {
        static void Main(string[] args)
        {
            var area = double.Parse(Console.ReadLine());
            var grapePerMeter = double.Parse(Console.ReadLine());
            var litres = double.Parse(Console.ReadLine());
            var workers = int.Parse(Console.ReadLine());

            double grape = area * grapePerMeter;
            double wine = (grape * 0.40)/2.5;
            double remaining = litres - wine;
            double good = wine - litres;
            double absRemaining = Math.Abs(litres - wine);
            double perPerson = absRemaining / workers;

            if (wine < litres)
            {
                Console.WriteLine("It will be a tough winter! More {0} liters wine needed.", Math.Floor(absRemaining));
            }
            else if (wine > litres)
            {
                Console.WriteLine("Good harvest this year! Total wine: {0} liters.", Math.Floor(wine));
                Console.WriteLine("{0} liters left -> {1} liters per person.", Math.Ceiling(good), perPerson);
            }
            else
            {
                Console.WriteLine("error");



            }
        }
    }
}
