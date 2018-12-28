using System;
using System.Linq;
using System.Text;

namespace _06.SumBigNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string num1 = Console.ReadLine();
            string num2 = Console.ReadLine();

            if (num1.Length > num2.Length)
            {
                num2 = num2.PadLeft(num1.Length, '0');
            }
            else if (num2.Length > num1.Length)
            {
                num1 = num1.PadLeft(num2.Length, '0');
            }
            StringBuilder sb = new StringBuilder();
            int sum = 0;
            int reminder = 0;
            int number = 0;

            for (int i = num1.Length-1; i >=0; i--)
            {
                sum = num1[i] - 48 + num2[i] - 48 + reminder;
                number = sum % 10;
                sb.Append(number);
                reminder = sum / 10;
                if (i == 0 && reminder > 0)
                {
                    sb.Append(reminder);
                }
            }
            Console.WriteLine(new string(sb.ToString().TrimEnd('0').ToCharArray().Reverse().ToArray()));
        }
    }
}