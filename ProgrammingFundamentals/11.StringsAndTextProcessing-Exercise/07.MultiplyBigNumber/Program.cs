using System;
using System.Linq;
using System.Text;

namespace _07.MultiplyBigNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            var num = Console.ReadLine();
            var multiplier = int.Parse(Console.ReadLine());
            var res = 0;
            var toAdd = 0;
            StringBuilder sb = new StringBuilder();
            for (int i = num.Length - 1; i >= 0; i--)
            {
                res = multiplier * int.Parse(num[i].ToString()) + toAdd;
                if (res > 9)
                {
                    if (i == 0)
                    {
   
                        sb.Append(res % 10);
                        sb.Append(res / 10);
                    }
                    else
                    {
                        toAdd = res / 10;
                        res = res % 10;
                        sb.Append(res);
                    }
                }
                else
                {
                    toAdd = 0;
                    sb.Append(res);
                }
            }
            var result = new string(sb.ToString().ToCharArray().Reverse().ToArray()).TrimStart('0');
            bool flagZero = true;
            foreach (var item in result)
            {
                if (item != '0')
                {
                    flagZero = false;
                }
            }
            if (flagZero)
            {
                result = "0";
            }
            Console.WriteLine(result);
        }
    }
}

