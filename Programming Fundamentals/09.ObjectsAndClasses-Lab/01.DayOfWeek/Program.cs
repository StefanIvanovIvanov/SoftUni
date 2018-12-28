using System;
using System.Globalization;
using System.Reflection;

namespace _01.DayOfWeek
{
    class Program
    {
        static void Main(string[] args)
        {
            var dateInput = Console.ReadLine();
            DateTime myDate = new DateTime();
            myDate = DateTime.ParseExact(dateInput, "d-M-yyyy", CultureInfo.InvariantCulture);
            Console.WriteLine(myDate.DayOfWeek);
        }
    }
}