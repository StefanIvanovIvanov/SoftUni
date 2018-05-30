using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivideWithoutRemain
{
    class Program
    {
        static void Main(string[] args)
        {
            double n = double.Parse(Console.ReadLine());

            double p1 = 0;
            double p2 = 0;
            double p3 = 0;

            for (int i = 1; i <= n; i++)
            {
                double p = double.Parse(Console.ReadLine());

                if (p % 2 == 0)
                {
                    p1 = p1 + 1;
                }
                if (p % 3 == 0)
                {
                    p2 = p2 + 1;
                }
                if (p % 4 == 0)
                {
                    p3 = p3 + 1;
                } 
            }
            double p1percent = (p1 / n) * 100;
            double p2percent = (p2 / n) * 100;
            double p3percent = (p3 / n) * 100;

            Console.WriteLine($"{p1percent:f2}%");
            Console.WriteLine($"{p2percent:f2}%");
            Console.WriteLine($"{p3percent:f2}%");
        }
    }
}
