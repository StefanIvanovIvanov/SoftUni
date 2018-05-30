using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.CountUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, bool> checker =s=> char.IsUpper(s[0]);
            Console.ReadLine().Split(new char[]{' '},StringSplitOptions.RemoveEmptyEntries)
                .Where(checker).ToList().ForEach(s=>Console.WriteLine(s));
        }
    }
}
