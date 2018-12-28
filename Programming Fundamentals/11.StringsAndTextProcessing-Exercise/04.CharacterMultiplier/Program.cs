using System;

namespace _04.CharacterMultiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(new []{' '});
            char[] charArray1 = input[0].ToCharArray();
            char[] charArray2 = input[1].ToCharArray();
            int sum = 0;

            int min = Math.Min(charArray1.Length, charArray2.Length);
            int max = Math.Max(charArray1.Length, charArray2.Length);

            for (int i = 0; i < min; i++)
            {
                int result = charArray1[i] * charArray2[i];
                sum = sum + result;
            }
            if (max == charArray1.Length)
            {
                for (int i = min; i < max; i++)
                {
                    sum += charArray1[i];
                }
            }
            else
            {
                for (int i = min; i < max; i++)
                {
                    sum += charArray2[i];
                }
            }
            Console.WriteLine(sum);
        }
    }
}