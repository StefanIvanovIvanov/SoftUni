using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    class Program
    {
        static void Main(string[] args)
        {
            var figure = Console.ReadLine();

            if (figure == "square")
            {
                var size = double.Parse(Console.ReadLine());
                Console.WriteLine(size * size);
            }
            else if (figure == "rectangle")
            {
                var a = double.Parse(Console.ReadLine());
                var b = double.Parse(Console.ReadLine());
                Console.WriteLine(a * b);
            }
            else if (figure == "circle")
            {
                var r = double.Parse(Console.ReadLine());
                Console.WriteLine(r * r * Math.PI);
            }
            else if (figure == "triangle")
            {
                var a = double.Parse(Console.ReadLine());
                var h = double.Parse(Console.ReadLine());
                Console.WriteLine((a * h) / 2);
            }
            else {
                Console.WriteLine("error");
                 }

        }
    }
}
