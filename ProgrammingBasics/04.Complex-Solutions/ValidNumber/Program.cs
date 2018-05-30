using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            var number = double.Parse(Console.ReadLine());

            if (number == 0 || number >= 100 && number <= 200)
            { Console.WriteLine(); }
            else { Console.WriteLine("invalid"); }
        }
    }
}
