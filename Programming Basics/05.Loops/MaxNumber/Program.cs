using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int evenNumbber = 0;
            int oddNumber = 0;

            for (int i = 1; i <= n; i++)
            {
                var entry = int.Parse(Console.ReadLine());
                if (i % 2 == 0)
                { evenNumbber = evenNumbber + entry; }

                else if (i % 2 != 0)
                { oddNumber = oddNumber + entry; }

            }

            var diff = Math.Abs(evenNumbber - oddNumber);

            if (evenNumbber == oddNumber)
            { Console.WriteLine("Yes Sum = " + evenNumbber); }
            else if (evenNumbber!=oddNumber)
            { Console.WriteLine("No Diff = " + diff); }
            

           
        }
    }
}
