using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seconds
{
    class Program
    {
        static void Main(string[] args)
        {
            var time1 = int.Parse(Console.ReadLine());
            var time2 = int.Parse(Console.ReadLine());
            var time3 = int.Parse(Console.ReadLine());

            var timeTotal = time1 + time2 + time3;

            var sixty = timeTotal - 60;
            var oneHundredAndTwenty = timeTotal - 120;

            //time<60
            if (timeTotal < 60 && timeTotal < 10)
            {
                Console.WriteLine("0:0"+timeTotal);
            }
            else if (timeTotal < 60)
            {
                Console.WriteLine("0:"+timeTotal);
            }
            //time<120
            else if (timeTotal < 120 && sixty < 10)
            {
                Console.WriteLine("1:0" + sixty);
            }
            else if (timeTotal < 120)
            {
                Console.WriteLine("1:" + sixty);
            }
            //time<180
            else if (timeTotal < 180 && oneHundredAndTwenty < 10)
            {
                Console.WriteLine("2:0" + oneHundredAndTwenty);
            }
            else if (timeTotal < 180)
            {
                Console.WriteLine("2:" + oneHundredAndTwenty);
            }
        }
    }
}
