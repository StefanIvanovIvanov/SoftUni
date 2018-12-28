using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomTheCat
{
    class Program
    {
        static void Main(string[] args)
        {
            double offDays = int.Parse(Console.ReadLine());
            double workDays = 365 - offDays;
            double workDaysPlay = workDays * 63;
            double offDaysPlay = offDays * 127;
            double totalPlayTime = offDaysPlay + workDaysPlay;
            double remainingTime = Math.Abs(30000 - totalPlayTime);
            double H = Math.Floor(remainingTime / 60);
            double M = Math.Truncate(remainingTime % 60);

    if (totalPlayTime > 30000)
    {
        Console.WriteLine("Tom will run away");
        Console.WriteLine($"{H} hours and {M} minutes more for play");
    } else if (totalPlayTime < 30000)
    {
        Console.WriteLine("Tom sleeps well");
        Console.WriteLine($"{H} hours and {M} minutes less for play");
    }
    else { Console.WriteLine("error");

    }
        }
    }

}
