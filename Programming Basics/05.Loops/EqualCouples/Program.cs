using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EqualCouples
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            double currSum = 0;
            double prevSum = 0;
            double diff = 0;
            double max = -10000;   

            for (int i = 1; i <= n; i++)
            {
                prevSum = currSum;
                currSum = 0;
                double entry1 = double.Parse(Console.ReadLine());
                double entry2 = double.Parse(Console.ReadLine());
                currSum = entry1 + entry2;

                if (i != 0)
                {
                    diff = Math.Abs(currSum - prevSum);
                    if (max < diff)
                    { max = diff; }
                }
            }
            
            if (diff==0||n==1)
            {
                Console.WriteLine("Yes, value = " + currSum);
            }
            else
            {
                Console.WriteLine("No, maxdiff = " + diff);


            }

        }
    }
    }

