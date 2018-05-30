using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conventor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter amount: ");
            var amount = double.Parse(Console.ReadLine());
            Console.WriteLine("Input Currency: ");
            var inputCurrency = Console.ReadLine();
            Console.WriteLine("Output Currency: ");
            var outputCurrency = Console.ReadLine();

            //BGN start

            if (inputCurrency == "BGN" && outputCurrency == "USD")
            {
                Console.WriteLine(Math.Round(amount / 1.79549, 2));
            }
            if (inputCurrency == "BGN" && outputCurrency == "EUR")
            { 
                Console.WriteLine(Math.Round(amount / 1.95583, 2));
            }
            if (inputCurrency == "BGN" && outputCurrency == "GBP")
            {
                Console.WriteLine(Math.Round(amount / 2.53405, 2));
            }
            if (inputCurrency == "BGN" && outputCurrency == "BGN")
            {
                Console.WriteLine(Math.Round(amount * 1, 2) + "BGN");
            }
            //BGN end

            //USD start
            if (inputCurrency == "USD" && outputCurrency == "BGN")
            {
                Console.WriteLine(Math.Round(amount * 1.79549, 2));
            }
            if (inputCurrency == "USD" && outputCurrency == "EUR")
            {
                Console.WriteLine(Math.Round((amount * 1.79549) / 1.95583, 2));
            }
            if (inputCurrency == "USD" && outputCurrency == "GBP")
            {
                Console.WriteLine(Math.Round((amount * 1.79549) / 2.53405, 2));
            }
            if (inputCurrency == "USD" && outputCurrency == "USD")
            {
                Console.WriteLine(Math.Round(amount * 1, 2) + "USD");
            }
            //USD end


            //GBP start
            if (inputCurrency == "GBP" && outputCurrency == "USD")
            {
                Console.WriteLine(Math.Round((amount * 2.53405) / 1.79549, 2));
            }
            if (inputCurrency == "GBP" && outputCurrency == "EUR")
            {
                Console.WriteLine(Math.Round((amount * 2.53405) / 1.95583, 2));
            }
            if (inputCurrency == "GBP" && outputCurrency == "BGN")
            {
                Console.WriteLine(Math.Round((amount * 2.53405), 2));
            }
            if (inputCurrency == "GBP" && outputCurrency == "GBP")
            {
                Console.WriteLine(Math.Round(amount * 1, 2));
            }
            //GBP end

            //EUR start
            if (inputCurrency == "EUR" && outputCurrency == "USD")
            {
                Console.WriteLine(Math.Round((amount * 1.95583) / 1.79549, 2));
            }
            if (inputCurrency == "EUR" && outputCurrency == "GBP")
            {
                Console.WriteLine(Math.Round((amount * 1.95583) / 2.53405, 2));
            }
            if (inputCurrency == "EUR" && outputCurrency == "BGN")
            {
                Console.WriteLine(Math.Round(amount * 1.95583, 2));
            }
            if (inputCurrency == "EUR" && outputCurrency == "EUR")
            {
                Console.WriteLine(Math.Round(amount * 1, 2));
            }
            //EUR end
        }
    }
}