using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddEvenSumMaxMin
{
    class Program
    {
        static void Main(string[] args)
        {
            double n = double.Parse(Console.ReadLine());
            double sumOdd = 0;
            double maxOdd = -1000000000;
            double minOdd = 1000000000;
            double sumEven = 0;
            double maxEven = -1000000000;
            double minEven = 1000000000;
            var no = "No";

            for (int i = 1; i <= n; i++)
            {
                var entry = double.Parse(Console.ReadLine());
                if (i % 2 == 0)
                {
                    sumEven = sumEven + entry;
                    if (maxEven < entry)
                    { maxEven = entry; }
                    
                    if (entry < minEven)
                    { minEven = entry; }
                    
                }
                else if (i % 2 != 0)
                {
                    sumOdd = sumOdd + entry;
                    if (maxOdd < entry)
                    { maxOdd = entry; }
                    
                    if (entry < minOdd)
                    { minOdd = entry; }
                    
                }
                
            }
            Console.WriteLine("OddSum = " + sumOdd);

            Console.Write("OddMin = ");
            if (-1000000000 < minOdd && minOdd < 1000000000) { Console.WriteLine(minOdd); }
            else Console.WriteLine("No");

            Console.Write("OddMax = ");
            if (-1000000000 < maxOdd && maxOdd < 1000000000) { Console.WriteLine(maxOdd); }
            else Console.WriteLine("No");

            Console.WriteLine("EvenSum = " + sumEven);

            Console.Write("EvenMin = ");
            if (-1000000000 < minEven && minEven < 1000000000) { Console.WriteLine(minEven); }
            else Console.WriteLine("No");

            Console.Write("EvenMax = ");
            if (-1000000000 < maxEven && maxEven < 1000000000) { Console.WriteLine(maxEven); }
            else Console.WriteLine("No");
        }
    }
}
