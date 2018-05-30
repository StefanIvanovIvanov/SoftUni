using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Celcium_to_Faranheim
{
    class Program
    {
        static void Main(string[] args)
        {
            var C = double.Parse(Console.ReadLine());
            var F = C*9/5+32;
            Console.WriteLine(Math.Round(F, 2));

        }
    }
}
