﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comission
{
    class Program
    {
        static void Main(string[] args)
        {
            var town = Console.ReadLine();
            double sales = double.Parse(Console.ReadLine());

            double comission = -1;

            if (town == "Sofia" && 0 <= sales)
            {
                if (0 <= sales && sales <= 500)
                { comission = 0.05; }
                else if (500 < sales && sales <= 1000)
                { comission = 0.07; }
                else if (1000 < sales && sales <= 10000)
                { comission = 0.08; }
                else if (10000 < sales)
                { comission = 0.12; }
                Console.WriteLine("{0:f2}", sales * comission);
            }

            else if (town == "Varna" && 0 <= sales)
            {
                if (0 <= sales && sales <= 500)
                { comission = 0.045; }
                else if (500 < sales && sales <= 1000)
                { comission = 0.075; }
                else if (1000 < sales && sales <= 10000)
                { comission = 0.1; }
                else if (10000 < sales)
                { comission = 0.13; }
                Console.WriteLine("{0:f2}", sales * comission);
            }

            else if (town == "Plovdiv" && 0<=sales)
            {
                if (0 <= sales && sales <= 500)
                { comission = 0.055; }
                else if (500 < sales && sales <= 1000)
                { comission = 0.08; }
                else if (1000 < sales && sales <= 10000)
                { comission = 0.12; }
                else if (10000 < sales)
                { comission = 0.145; }
                Console.WriteLine("{0:f2}", sales * comission);
            }
            else if ((town != "Sofia" && town != "Plovdiv" && town != "Varna")||0>sales)
            { Console.WriteLine("error"); }



        }
       
    }
}
