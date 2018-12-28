using System;

namespace DateIn5Days
{
    class Program
    {
        static void Main(string[] args)
        {
            double d = double.Parse(Console.ReadLine());
            double m = double.Parse(Console.ReadLine());

            double numOfDays = -1;
            if (m == 4 || m == 6 || m == 9 || m == 11 || m == 04 || m == 06 || m == 09)
            {
                numOfDays = 30;
            }
            else if (m == 2 || m == 02)
            {
                numOfDays = 28;
            }
            else if (m == 1 || m == 3 || m == 5 || m == 7 || m == 8 || m == 10 || m == 12 || m == 01 || m == 03  || m == 05 || m == 07 || m == 08)
            {
                numOfDays = 31;
            }

            d = d + 5;

            if (d > numOfDays)
            {
                d = d - numOfDays;
                m = m + 1;
                if (m > 12)
                {
                    m = 1;
                }
            }
            
            if(m<10)
                Console.WriteLine("{0}.0{1}",d,m);
            else Console.WriteLine("{0}.{1}", d, m);
        }

    }

}
