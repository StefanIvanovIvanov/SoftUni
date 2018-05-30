using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLily
{
    class Program
    {
        static void Main(string[] args)
        {
            double age = double.Parse(Console.ReadLine());
            double washingMachinePrice = double.Parse(Console.ReadLine());
            double toyPrice = double.Parse(Console.ReadLine());
            double moneyTotal = 0;
            double moneyAdd = 0;
            double toys = 0;
            double brother = 0;

            for (double i = 1; i <= age; i++)
            {
                if (i % 2 == 0)
                {
                    moneyAdd = moneyAdd += 10;
                    moneyTotal = moneyTotal + moneyAdd;
                    brother = brother + 1;
                }
                else if (i % 2 != 0)
                {
                    toys = toys + 1;
                }
            }
            double moneyFromToys = toys * toyPrice;
            double finalAmount = moneyTotal + moneyFromToys - brother;

            double N = finalAmount - washingMachinePrice;
            double M = Math.Abs(finalAmount = washingMachinePrice);

            if (finalAmount >= washingMachinePrice)
            {
                Console.WriteLine($"Yes! {N:f2}");
            } else if (finalAmount < washingMachinePrice)
            {
                Console.WriteLine($"No! {M:f2}");
            }
            else Console.WriteLine("error");

        }
    }
}
