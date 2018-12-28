using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeftAndRightSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int num1 = 0;
            int num2 = 0;

            for (int i = 0; i < n; i++)
            {
                int entry1 = int.Parse(Console.ReadLine());
                num1 = num1 + entry1; 
            }

            for (int i = 0; i < n; i++)
            {
                int entry2 = int.Parse(Console.ReadLine());
                num2 = num2 + entry2;
            }

            int sum = num1 + num2;
            int diff = Math.Abs(num1 - num2);

                if (num1 == num2)
            { Console.WriteLine("Yes, sum = " + num1); }
            else if (num1 != num2)
            { Console.WriteLine("No, diff = " + diff); }
        }
    }
}
