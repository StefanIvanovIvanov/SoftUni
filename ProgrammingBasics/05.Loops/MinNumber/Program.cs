using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int num = int.Parse(Console.ReadLine());
            int max = 0;
            for (int i = 0; i < n - 1; i++)
            {
                int entry = int.Parse(Console.ReadLine());

                if (num > entry)
                { num = entry; }

            }
            Console.WriteLine(num);
        }
    }
}
