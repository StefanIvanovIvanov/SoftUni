using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine().Split(new []{' '},StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).OrderBy(n=>n).Take(1).ToList().ForEach(n=>Console.WriteLine(n));
        }
    }
}
