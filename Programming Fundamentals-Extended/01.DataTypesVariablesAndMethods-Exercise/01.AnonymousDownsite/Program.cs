using System;
using System.Linq;
using System.Numerics;

namespace _01.AnonymousDownsite
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int securityKey = int.Parse(Console.ReadLine());
            decimal totalLoss = 0;
            int count = 0;
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().
                    Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string siteName = input[0];
                uint siteVisits = uint.Parse(input[1]);
                decimal siteCommercialPricePerVisit = decimal.Parse(input[2]);
                decimal siteLoss = siteVisits * siteCommercialPricePerVisit;
                totalLoss += siteLoss;
                Console.WriteLine(siteName);
                count++;
            }
            Console.WriteLine("Total Loss: {0:f20}", totalLoss);
            BigInteger securityToken = BigInteger.Pow(securityKey, count);
            Console.WriteLine("Security Token: {0}", securityToken);
        }
    }
}