using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaOfCircle
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("r= ");
            var r = double.Parse(Console.ReadLine());
            var area = Math.PI * r * r;
            Console.Write("Area is ");
            Console.WriteLine(area);
            var perimeter = 2 * Math.PI * r;
            Console.Write("Perimeter is ");
            Console.WriteLine(perimeter);
        }
    }
}
