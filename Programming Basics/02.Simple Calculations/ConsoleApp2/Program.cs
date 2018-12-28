using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Inches=");
            var inches = double.Parse(Console.ReadLine());
            var cm = inches * 2.2;
            Console.Write("cm=");
            Console.WriteLine(cm);
        }
    }
}
