using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitStore
{
    class Program
    {
        static void Main(string[] args)
        {
            var fruit = Console.ReadLine();
            var weekday = Console.ReadLine();
            var amount = double.Parse(Console.ReadLine());

            double price = 1;

            if ((weekday == "Monday" || weekday == "Tuesday" || weekday == "Wednesday" || weekday == "Thursday" || weekday == "Friday")&&(fruit != "tomato" && fruit != "beer"))
            {
                if (fruit == "banana")
                {
                    price = 2.5;
                }
                else if (fruit == "apple")
                {
                    price = 1.2;
                }
                else if (fruit == "orange")
                {
                    price = 0.85;
                }
                else if (fruit == "grapefruit")
                {
                    price = 1.45;
                }
                else if (fruit == "kiwi")
                {
                    price = 2.70;
                }
                else if (fruit == "pineapple")
                {
                    price = 5.50;
                }
                else if (fruit == "grapes")
                {
                    price = 3.85;
                }
                double result = amount * price;
                Console.WriteLine("{0:f2}", result);
            }
            else if ((weekday == "Saturday" || weekday == "Sunday")&&(fruit != "tomato" && fruit != "beer"))
            {
                if (fruit == "banana")
                {
                    price = 2.70;
                }
                else if (fruit == "apple")
                {
                    price = 1.25;
                }
                else if (fruit == "orange")
                {
                    price = 0.90;
                }
                else if (fruit == "grapefruit")
                {
                    price = 1.60;
                }
                else if (fruit == "kiwi")
                {
                    price = 3.00;
                }
                else if (fruit == "pineapple")
                {
                    price = 5.60;
                }
                else if (fruit == "grapes")
                {
                    price = 4.20;
                }
                double result = amount * price;
                Console.WriteLine("{0:f2}", result);
            }
            
            else Console.WriteLine("error");
        } 
        
        
    }
}
