using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dates
{
    class Program
    {
        public static IFormatProvider InvariantCulture { get; private set; }

        static void Main(string[] args)
        {
            {
                var input = Console.ReadLine();
                var format = "dd-mm-yyyy";
                var date = DateTime.ParseExact(input, format, CultureInfo.InvariantCulture);
                date = date.AddDays(999);
                Console.WriteLine(date.ToString(format));

            }
        }
    }
}