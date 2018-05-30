using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03.PhoenixGrid
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (input != "ReadMe")
            {
                bool isPalindrom = true;
                string pattern = @"^([^\s_]{3})(\.([^\s_]{3}))*$";
                Match match = Regex.Match(input, pattern);

                if (match.Success)
                {
                    for (int i = 0; i < input.Length/2; i++)
                    {
                        if (input[i] != input[input.Length - 1 - i])
                        {
                            isPalindrom = false;
                            break;
                        }
                    }
                    if (isPalindrom)
                    {
                        Console.WriteLine("YES");
                    }
                    else
                    {
                        Console.WriteLine("NO");
                    }
                }
                else
                {
                    Console.WriteLine("NO");
                }                
                input = Console.ReadLine();
            }
        }
    }
}