using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.Tuple
{
    class Program
    {
        static void Main(string[] args)
        { 
            var tokens = GetTokens();

            Tuple<string, string> tupleOne = new Tuple<string, string>((tokens[0] + " " + tokens[1]), tokens[2]);

            tokens = GetTokens();

            Tuple<string, int> tupleTwo = new Tuple<string, int>(tokens[0], int.Parse(tokens[1]));

            tokens = GetTokens();

            Tuple<int, double> tupleThree = new Tuple<int, double>(int.Parse(tokens[0]), double.Parse(tokens[1]));

            Console.WriteLine(tupleOne.ToString());
            Console.WriteLine(tupleTwo.ToString());
            Console.WriteLine(tupleThree.ToString());
        }

        private static List<string> GetTokens()
        {
            return Console.ReadLine().Split(new[] { ' ' }).ToList();
        }
    }
}
