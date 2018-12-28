using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vowels
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = Console.ReadLine();
            var sum = 0;

            for (int i = 0; i <= s.Length-1; i++)
            { var letter = s[i];
                if (letter == 'a') sum += 1;
                else if (letter == 'e') sum += 2;
                else if (letter == 'i') sum += 3;
                else if (letter == 'o') sum += 4;
                else if (letter == 'u') sum += 5;

            }
            Console.WriteLine(sum);


        }
    }
}
