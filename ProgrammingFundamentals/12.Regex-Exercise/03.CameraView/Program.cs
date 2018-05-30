using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _03.CameraView
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] elements = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int skip = elements[0];
            int take = elements[1];
            string input = Console.ReadLine();
            string pattern = "\\|<(\\w{" + skip + "})(\\w{0," + take + "})";

            MatchCollection matches = Regex.Matches(input, pattern);

            List<string> res = new List<string>();
            foreach (Match m in matches)
            {
                res.Add(m.Groups[2].Value);
            }
            Console.WriteLine(string.Join(", ", res));
        }
    }
}