using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char>stack=new Stack<char>(input.ToCharArray());
            while (stack.Count > 0)
            {
                Console.Write(stack.Pop().ToString());
            }
        }
    }
}
