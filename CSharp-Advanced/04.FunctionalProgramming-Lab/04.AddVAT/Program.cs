using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.AddVAT
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse).Select(d => d * 1.2).ToList().ForEach(d => Console.WriteLine($"{d:f2}"));
        }
    }
}
