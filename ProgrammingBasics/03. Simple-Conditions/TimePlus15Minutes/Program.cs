using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimePlus15Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            var Hours = int.Parse(Console.ReadLine());
            var Minutes = int.Parse(Console.ReadLine());

            Minutes = Minutes + 15;

            if (Minutes >= 60)
            {
                Minutes = Minutes - 60;
                Hours = Hours + 1;
            }

            if (Hours == 24)
                Hours = 0;

            if(Minutes<10)
            Console.WriteLine("{0}:0{1}", Hours, Minutes);
            else
                Console.WriteLine("{0}:{1}", Hours, Minutes);




        }




    }

}


