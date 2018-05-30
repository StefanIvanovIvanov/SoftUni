using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.JediMeditation
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> masters = new List<string>();
            List<string> knights = new List<string>();
            List<string> padawans = new List<string>();
            List<string> toshkoAndSlav = new List<string>();
            List<string> yoda = new List<string>();
           
            for (int i = 0; i < n; i++)
            {
                string[] jedi = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                
                foreach (string j in jedi)
                {
                    if (j.StartsWith("m"))
                    {
                        masters.Add(j);
                    }
                    else if (j.StartsWith("k"))
                    {
                        knights.Add(j);
                    }
                    else if (j.StartsWith("p"))
                    {
                        padawans.Add(j);
                    }
                    else if (j.StartsWith("y"))
                    {
                        yoda.Add(j);
                    }
                    else if (j.StartsWith("t")|| j.StartsWith("s"))
                    {
                        toshkoAndSlav.Add(j);
                    }
                }

            }

            if (yoda.Any())
            {
                Console.WriteLine(string.Join(" ", masters) + " " + string.Join(" ", knights) + " " + string.Join(" ", toshkoAndSlav) + " " + string.Join(" ", padawans));
            }
            else
            {
                Console.WriteLine(string.Join(" ", toshkoAndSlav) + " " + string.Join(" ", masters) + " " + string.Join(" ", knights) + " " + string.Join(" ", padawans));
            }
        }
    }
}
