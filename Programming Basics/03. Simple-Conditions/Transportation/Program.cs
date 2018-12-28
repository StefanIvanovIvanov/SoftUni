using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transportation
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = double.Parse(Console.ReadLine());
            var time = Console.ReadLine();

            var taxiDay = 0.70 + 0.79 * n;
            var taxiNight = 0.70 + 0.90 * n;
            var bus = 0.09 * n;
            var train = 0.06 * n;

            if (n >= 100)
            {
                Console.WriteLine(train);
            }
            else if (n >= 20)
            {
                Console.WriteLine(bus);
            }
            else if (n < 20 && time == "night")
            {
                Console.WriteLine(taxiNight);
            }
            else if (n < 20 && time == "day")
            {
                Console.WriteLine(taxiDay);
            }
            else {
                Console.WriteLine("error");
            }
        }
    }
}
