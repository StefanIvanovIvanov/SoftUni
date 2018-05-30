using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excellent_Or_Not
{
    class Program
    {
        static void Main(string[] args)
        {
            double entry = double.Parse(Console.ReadLine());
            if (entry >= 5.50) { Console.WriteLine("Excellent!"); }
            else
            { Console.WriteLine("Not excellent."); }
        }
    }
}
