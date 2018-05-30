using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.DecimalToBinaryConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();
            if (input == 0)
            {
                Console.WriteLine(0);
                return;
            }
            while (input > 0)
            {
                stack.Push(input % 2);
                input = input / 2;
            }
            while (stack.Count > 0)
            {
                Console.Write(stack.Pop());
            }
            Console.WriteLine();
        }
    }
}
