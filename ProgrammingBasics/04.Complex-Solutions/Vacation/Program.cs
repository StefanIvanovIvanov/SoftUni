using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            // При 100лв. или по-малко – някъде в България
            // Лято – 30% от бюджета
            // Зима – 70% от бюджета
            //При 1000лв. или по малко – някъде на Балканите
            // Лято – 40% от бюджета
            //Зима – 80% от бюджета
            //При повече от 1000лв. – някъде из Европа
            // При пътуване из Европа, независимо от сезона ще похарчи 90% от бюджета.


            var budged = double.Parse(Console.ReadLine());
            var season = Console.ReadLine();

            if (budged <= 100 && season == "summer")
            {
                Console.WriteLine("Somewhere in Bulgaria");
                Console.WriteLine("Camp - " + "{0:f2}", budged * 0.30);
            } else if (budged <= 100 && season == "winter") { 
                Console.WriteLine("Somewhere in Bulgaria");
            Console.WriteLine("Hotel - " + "{0:f2}", budged * 0.70);
        }

            else if (100 < budged && budged <= 1000 && season == "summer")
            {
                Console.WriteLine("Somewhere in Balkans");
                Console.WriteLine("Camp - " + "{0:f2}", budged * 0.40);
            }
            else if (100 < budged && budged <= 1000 && season == "winter")
            {
                Console.WriteLine("Somewhere in Balkans");
                Console.WriteLine("Hotel - " + "{0:f2}", budged * 0.80);
            }
            else if (budged > 1000) {
                Console.WriteLine("Somewhere in Europe");
                Console.WriteLine("Hotel - " + "{0:f2}", budged * 0.90);
            }
        }
        
        }

        
    }
