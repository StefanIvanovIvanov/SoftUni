

namespace _02.MaxMethod
{
    using System;
    class StartUp
    {
       public static void Main()
        {
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());
            int n3 = int.Parse(Console.ReadLine());

            int firstHigherNumber = Math.Max(n1, n2);
            int secondHigherNumber = Math.Max(n2, n3);
            if (firstHigherNumber == secondHigherNumber)
            {
                secondHigherNumber = Math.Max(n1, n3);
            }
            Console.WriteLine(GetMax(firstHigherNumber, secondHigherNumber));
        }
        static int GetMax(int a, int b)
        {
            int higherNumber = Math.Max(a, b);
            return higherNumber;
        }
    }
}