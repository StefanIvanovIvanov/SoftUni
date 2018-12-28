using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvenOrNot
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            int num1 = 0;
            int num2 = 0;

            for (int i= 0; i < n; i+=2)
            {
                int entry1 = int.Parse(Console.ReadLine());
                num1 = num1 + entry1;
            }

            for (int i=1; i < n; i += 2)
            {
                int entry2 = int.Parse(Console.ReadLine());
                num2 = num2 + entry2;
            }
            Console.WriteLine(num1);
            Console.WriteLine(num2);

        }
    }
}
