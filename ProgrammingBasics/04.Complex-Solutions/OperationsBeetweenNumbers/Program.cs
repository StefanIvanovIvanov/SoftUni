using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationsBeetweenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double n1 = double.Parse(Console.ReadLine());
            double n2 = double.Parse(Console.ReadLine());
            var op = Console.ReadLine();
            var plus = n1 + n2;
            var minus = n1 - n2;
            var multiply = n1 * n2;
            var divide = n1 / n2;
            
            var remain = n1 % n2;

            if (n2 == 0 && (op == "/" || op == "%"))
            {
                Console.WriteLine("Cannot divide {0} by zero", n1);
            }
            else if (op == "+" && plus%2==0)
            {
                Console.WriteLine("{0} + {1} = {2} - even", n1, n2, plus);
            }
            else if (op == "+" && plus % 2 != 0)
            {
                Console.WriteLine("{0} + {1} = {2} - odd", n1, n2, plus);
            }
            else if (op == "-" && minus % 2 == 0)
            {
                Console.WriteLine("{0} - {1} = {2} - even", n1, n2, minus);
            }
            else if (op == "-" && minus % 2 != 0)
            {
                Console.WriteLine("{0} - {1} = {2} - odd", n1, n2, minus);
            }
            else if (op == "*" && multiply % 2 == 0)
            {
                Console.WriteLine("{0} * {1} = {2} - even", n1, n2, multiply);
            }
            else if (op == "*" && multiply % 2 != 0)
            {
                Console.WriteLine("{0} * {1} = {2} - odd", n1, n2, multiply);
            }
            else if (op == "/")
            {
                Console.WriteLine(n1 + " / " + n2 + " = " + "{0:0.00}", divide);
            }
            else if (op == "%")
            {
                Console.WriteLine("{0} % {1} = {2}", n1, n2, remain);
            }
            else Console.WriteLine("error");


        }
    }
}
