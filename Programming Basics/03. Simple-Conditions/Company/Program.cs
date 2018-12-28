using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company
{
    class Program
    {
        static void Main(string[] args)
        {
            var hours = double.Parse(Console.ReadLine());
            var days = double.Parse(Console.ReadLine());
            var overTime = double.Parse(Console.ReadLine());

            var trainingDays = days * 0.1;
            var workDays = days - trainingDays;
            var overTimeHours = Math.Floor(overTime*(days * 2));




            var workHours = Math.Floor(workDays * 8);
            var workHoursTotal = workHours + overTimeHours;
            var remaining = Math.Abs(hours - workHoursTotal);

            if (hours > workHoursTotal)
            {
                Console.WriteLine("Not enough time!{0} hours needed.", remaining);
            } else if (hours<= workHoursTotal)
                {
                Console.WriteLine("Yes!{0} hours left.", remaining);
            }
            else Console.WriteLine("false");

        }
    }
}
