using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    class Program
    {
        static void Main(string[] args)
        {
            var product = Console.ReadLine();
            var town = Console.ReadLine();
            var amount = double.Parse(Console.ReadLine());

            if (product == "coffee")
            {
                if (town == "Sofia")
                {
                    Console.WriteLine(amount * 0.50);
                }
                else if (town == "Plovdiv")
                {
                    Console.WriteLine(amount * 0.40);
                }
                else if (town == "Varna")
                {
                    Console.WriteLine(amount*0.45);
                }
            }
            if (product == "water")
            {
                if (town == "Sofia")
                {
                    Console.WriteLine(amount * 0.80);
                }
                else if (town == "Plovdiv")
                {
                    Console.WriteLine(amount * 0.70);
                }
                else if (town == "Varna")
                {
                    Console.WriteLine(amount * 0.70);
                }
            }
            if (product == "beer")
            {
                if (town == "Sofia")
                {
                    Console.WriteLine(amount * 1.20);
                }
                else if (town == "Plovdiv")
                {
                    Console.WriteLine(amount * 1.15);
                }
                else if (town == "Varna")
                {
                    Console.WriteLine(amount * 1.10);
                }
            }
            if (product == "sweets")
            {
                if (town == "Sofia")
                {
                    Console.WriteLine(amount * 1.45);
                }
                else if (town == "Plovdiv")
                {
                    Console.WriteLine(amount * 1.30);
                }
                else if (town == "Varna")
                {
                    Console.WriteLine(amount * 1.35);
                }
            }
            if (product == "peanuts")
            {
                if (town == "Sofia")
                {
                    Console.WriteLine(amount * 1.60);
                }
                else if (town == "Plovdiv")
                {
                    Console.WriteLine(amount * 1.50);
                }
                else if (town == "Varna")
                {
                    Console.WriteLine(amount * 1.55);
                }
            }
           
            
        }
    }
}
