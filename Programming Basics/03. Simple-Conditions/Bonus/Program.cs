using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonus
{
    class Program
    {
        static void Main(string[] args)
        {
           var bonus = int.Parse(Console.ReadLine());

            if (bonus <= 100 && bonus % 2 == 0)
            {
                Console.WriteLine(5 + 1);
                Console.WriteLine(bonus + 5 + 1);
            }
            else if (bonus <= 100 && bonus % 5 == 0)
            {
                Console.WriteLine(5 + 2);
                Console.WriteLine(bonus + 5 + 2);
            }
            else if (bonus <= 100)
            {
                Console.WriteLine(5);
                Console.WriteLine(bonus+5);
            }
            else if (bonus <= 1000 && bonus % 2 == 0)
            {
                Console.WriteLine(bonus * 0.20 + 1);
                Console.WriteLine(bonus + bonus * 0.20 + 1);
            }
            else if (bonus <= 1000 && bonus % 5 == 0)

            {
                Console.WriteLine(bonus * 0.20 + 2);
                Console.WriteLine(bonus + bonus * 0.20 + 2);
            }
            else if (bonus <= 1000)

            {
                Console.WriteLine(bonus * 0.20);
                Console.WriteLine(bonus + bonus * 0.20);
            }
            else if (bonus>1000 && bonus%2==0)
            {
                Console.WriteLine(bonus*0.10 + 1);
                Console.WriteLine(bonus + bonus*0.10+1);
            }
            else if (bonus > 1000 && bonus % 5 == 0)
            {
                Console.WriteLine(bonus * 0.10 + 2);
                Console.WriteLine(bonus + bonus * 0.10 + 2);
            }
            else if (bonus > 1000)
            {
                Console.WriteLine(bonus * 0.10);
                Console.WriteLine(bonus + bonus * 0.10);
            }
        }


        }
    }

