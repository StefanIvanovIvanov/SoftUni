using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volleyball
{
    class Program
    {
        static void Main(string[] args)
        {
               
            var year = Console.ReadLine();
            double p = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());

            var daysInSofia = 48 - h;
            var holidayGames = p * 2 / 3;
            var notWorking = daysInSofia * 3 / 4;
            var total = notWorking + h + holidayGames;

            if (year == "leap") { total = total + total * 0.15; }

            Console.WriteLine(Math.Truncate(total));
        }
    }
}
