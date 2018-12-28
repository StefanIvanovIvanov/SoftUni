using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tiles
{
    class Program
    {
        static void Main(string[] args)
        {
            //patio area
            double N = double.Parse(Console.ReadLine());
            //tile width
            double W = double.Parse(Console.ReadLine());
            //tile length
            double L = double.Parse(Console.ReadLine());
            //bench width
            double M = double.Parse(Console.ReadLine());
            //bench length
            double O = double.Parse(Console.ReadLine());

            double patioArea = N * N;
            double tileArea = W * L;
            double benchArea = M * O;

            double workArea = patioArea - benchArea;
            double numberTiles = (workArea / tileArea);
            double timeNeeded = numberTiles * 0.20;

            Console.WriteLine(numberTiles.ToString("F"));
            Console.WriteLine(timeNeeded.ToString("F"));
        }
    }
}
