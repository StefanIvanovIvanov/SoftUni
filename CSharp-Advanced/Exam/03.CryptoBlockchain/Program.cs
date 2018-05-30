using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _03.CryptoBlockchain
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            StringBuilder sb=new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                sb.Append(input);
            }
            string final = sb.ToString();

            string pattern = @"\{[^\d]*(?<number>[\d]+)[^\d]*\}|\[[^\d]*(?<number>[\d]+)[^\d]*\]";

            Regex rgx=new Regex(pattern);
            StringBuilder sentence=new StringBuilder();

            MatchCollection matches = rgx.Matches(final);
            List<int>finalNumbers=new List<int>();
            List<char>chars=new List<char>();
            StringBuilder result = new StringBuilder();
            foreach (Match m in matches)
            {
                string currentNum = m.Groups["number"].Value;
                int index = 0;
                int currentLength = m.Value.Length;
                if (currentNum.Length % 3 == 0)
                {              
                    for (int i = 0; i < currentNum.Length/3; i++)
                    {
                        string three = currentNum.Substring(index, 3);
                        finalNumbers.Add(int.Parse(three));
                        index += 3;
                    }                  
                }
                foreach (var number in finalNumbers)
                {
                    result.Append(Convert.ToChar(number-currentLength));
                }
                finalNumbers.Clear();
            }
            Console.WriteLine(result);
        }
    }
}
