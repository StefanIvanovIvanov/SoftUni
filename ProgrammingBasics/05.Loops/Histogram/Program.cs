using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Histogram
{
    class Program
    {
        static void Main(string[] args)
        {
            double n = double.Parse(Console.ReadLine());
            double p1 = 0;
            double p2 = 0;
            double p3 = 0;
            double p4 = 0;
            double p5 = 0;

            for (double i = 1; i <= n; i++)
            {
                double p = double.Parse(Console.ReadLine());

                if (p < 200)
                {
                    p1 = p1 + 1;
                }
                else if (200 <= p && p < 400)
                {
                    p2 = p2 + 1;
                }
                else if (400 <= p && p < 600)
                {
                    p3 = p3 + 1;
                }
                else if (600 <= p && p < 800)
                {
                    p4 = p4 + 1;
                }
                else if (800 <= p)
                {
                    p5 = p5 + 1;
                }              
            }
            double p1percent = (p1 / n) * 100;
            double p2percent = (p2 / n) * 100;
            double p3percent = (p3 / n) * 100;
            double p4percent = (p4 / n) * 100;
            double p5percent = (p5 / n) * 100;

            Console.WriteLine($"{p1percent:f2}%");
            Console.WriteLine($"{p2percent:f2}%");
            Console.WriteLine($"{p3percent:f2}%");
            Console.WriteLine($"{p4percent:f2}%");
            Console.WriteLine($"{p5percent:f2}%");
        }
    }
}
