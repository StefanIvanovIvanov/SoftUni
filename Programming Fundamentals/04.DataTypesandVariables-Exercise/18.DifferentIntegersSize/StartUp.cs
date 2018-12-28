using System;

namespace _18.DifferentIntegersSize
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            try
            {
                long number = long.Parse(input);
                sbyte sbyteMax = sbyte.MaxValue;
                sbyte sbyteMin = sbyte.MinValue;

                byte byteMax = byte.MaxValue;
                byte byteMin = byte.MinValue;

                short shortMax = short.MaxValue;
                short shortMin = short.MinValue;

                ushort ushortMax = ushort.MaxValue;
                ushort ushortMin = ushort.MinValue;

                int intMax = int.MaxValue;
                int intMin = int.MinValue;

                uint uintMax = uint.MaxValue;
                uint uintMin = uint.MinValue;

                long longMax = long.MaxValue;
                long longMin = long.MinValue;

                Console.WriteLine($"{number} can fit in:");

                if (sbyteMin <= number && number <= sbyteMax)
                {
                    Console.WriteLine("* sbyte");
                }
                if (byteMin <= number && number <= byteMax)
                {
                    Console.WriteLine("* byte");
                }
                if (shortMin <= number && number <= shortMax)
                {
                    Console.WriteLine("* short");
                }
                if (ushortMin <= number && number <= ushortMax)
                {
                    Console.WriteLine("* ushort");
                }
                if (intMin <= number && number <= intMax)
                {
                    Console.WriteLine("* int");
                }
                if (uintMin <= number && number <= uintMax)
                {
                    Console.WriteLine("* uint");
                }
                if (longMin <= number && number <= longMax)
                {
                    Console.WriteLine("* long");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"{input} can't fit in any type");
            }
        }
    }
}