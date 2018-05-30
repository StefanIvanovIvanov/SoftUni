using System;
using System.Collections.Generic;
using System.Linq;


    class Program
    {
        static void Main(string[] args)
        {
            List<string> tokens = GetTokens();

            Tuple<string, string, string> threeupleOne = new Tuple<string, string, string>((tokens[0] + " " + tokens[1]), tokens[2], tokens[3]);

            tokens = GetTokens();

            Tuple<string, int, bool> threeupleTwo = new Tuple<string, int, bool>(tokens[0], int.Parse(tokens[1]), tokens[2] == "drunk" ? true : false);

            tokens = GetTokens();

            Tuple<string, double, string> threeupleThree = new Tuple<string, double, string>(tokens[0], double.Parse(tokens[1]), tokens[2]);

            Console.WriteLine(threeupleOne);
            Console.WriteLine(threeupleTwo);
            Console.WriteLine(threeupleThree);
        }

        private static List<string> GetTokens()
        {
            return Console.ReadLine().Split().ToList();
        }
    }

