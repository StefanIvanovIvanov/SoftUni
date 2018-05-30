using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metres
{
    class Program
    {
        static void Main(string[] args)
        {
            double inputNumber = double.Parse(Console.ReadLine());
            var entryUnit = Console.ReadLine();
            var outputUnit = Console.ReadLine();
            //Input
            if (entryUnit == "m")
            {
                inputNumber = inputNumber;
            }
            else if (entryUnit == "mm")
            {
                inputNumber = inputNumber / 1000;
            }
            else if (entryUnit == "cm")
            {
                inputNumber = inputNumber / 100;
            }
            else if (entryUnit == "mi")
            {
                inputNumber = inputNumber / 0.000621371192;
            }
            else if (entryUnit == "in")
            {
                inputNumber = inputNumber / 39.3700787;
            }
            else if (entryUnit == "km")
            {
                inputNumber = inputNumber / 0.001;
            }
            else if (entryUnit == "ft")
            {
                inputNumber = inputNumber / 3.2808399;
            }
            else if (entryUnit == "yd")
            {
                inputNumber = inputNumber / 1.0936133;
            }
            //Output
            if(outputUnit == "m")
            {
                inputNumber = inputNumber;
            }
            else if (outputUnit == "mm")
            {
                inputNumber = inputNumber * 1000;
            }
            else if (outputUnit == "cm")
            {
                inputNumber = inputNumber * 100;
            }
            else if (outputUnit == "mi")
            {
                inputNumber = inputNumber * 0.000621371192;
            }
            else if (outputUnit == "in")
            {
                inputNumber = inputNumber * 39.3700787;
            }
            else if (outputUnit == "km")
            {
                inputNumber = inputNumber * 0.001;
            }
            else if (outputUnit == "ft")
            {
                inputNumber = inputNumber * 3.2808399;
            }
            else if (outputUnit == "yd")
            {
                inputNumber = inputNumber * 1.0936133;
            }
            Console.WriteLine(inputNumber);
        }
    }
}
