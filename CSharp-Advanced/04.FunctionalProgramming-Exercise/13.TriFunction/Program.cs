using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine().Split().ToList();
            var filter = CreateFilter(sum);
         //   Func<String, int, bool> filter = (name, sum) => name.ToCharArray().Sum(c => c) >= sum;

            Console.WriteLine(names.FirstOrDefault(filter));
           // Console.WriteLine(names.FirstOrDefault(name=>name.ToCharArray().Sum(c=>c)>= sumInput));
        }

        static Func<string, bool> CreateFilter(int sum)
        {
            return name => name.ToCharArray().Sum(c => c) >= sum;
        }
    }
}
