using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Even_Number
{
    class Program
    {
        static void Main(string[] args)
        {

            var number = double.Parse(Console.ReadLine());

            if (number % 2 == 0)
            {
                Console.WriteLine("even");
            }
            else {
                Console.WriteLine("odd");
            }
        }
    }
}
