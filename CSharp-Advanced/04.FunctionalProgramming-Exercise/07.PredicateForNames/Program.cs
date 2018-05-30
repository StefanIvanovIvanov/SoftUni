using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            var length = int.Parse(Console.ReadLine());
            var names = Console.ReadLine().Split().ToList();

            var result = names.FindAll(delegate (string name)
            {
                return name.Length <= length;
            });

            Console.WriteLine(string.Join(Environment.NewLine, result));
        }
    }
}
