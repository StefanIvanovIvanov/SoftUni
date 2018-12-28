using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figure
{
    class Program
    {
        static void Main(string[] args)
        {

            var h = double.Parse(Console.ReadLine());
            var x = double.Parse(Console.ReadLine());
            var y = double.Parse(Console.ReadLine());

            var px1 = h * 3;
            var py1 = h;
            var left = h;
            var right = h * 2;
            var top = h * 4;

            if ((y > h && x < left) || (y > h && x > right) || y > top || y < 0 || x < 0 || x > px1)
            { Console.WriteLine("outside"); }
            else if (x == 0 || y == 0)
            { Console.WriteLine("border"); }
            else if ((y < h && y > 0 && 0 < x && x < px1) || (x > left && x < right && y < top))
            {
                Console.WriteLine("inside");
            }
            
            else Console.WriteLine("border");
        }
    }
}