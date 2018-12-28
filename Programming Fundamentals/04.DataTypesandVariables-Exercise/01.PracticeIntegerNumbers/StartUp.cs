using System;

namespace _01.PracticeIntegerNumbers
{
    class StartUp
    {
        static void Main(string[] args)
        {   //Input:
            //-100
            //128
            //- 3540
            //64876
            //2147483648
            //- 1141583228
            //- 1223372036854775808

            sbyte num1 = sbyte.Parse(Console.ReadLine());
            byte num2 = byte.Parse(Console.ReadLine());
            short num3 = short.Parse(Console.ReadLine());
            ushort num4 = ushort.Parse(Console.ReadLine());
            uint num5 = uint.Parse(Console.ReadLine());
            int num6 = int.Parse(Console.ReadLine());
            long num7 = long.Parse(Console.ReadLine());

            Console.WriteLine(num1);
            Console.WriteLine(num2);
            Console.WriteLine(num3);
            Console.WriteLine(num4);
            Console.WriteLine(num5);
            Console.WriteLine(num6);
            Console.WriteLine(num7);
        }
    }
}