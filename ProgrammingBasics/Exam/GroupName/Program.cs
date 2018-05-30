using System;

namespace GroupName
{
    class Program
    {
        static void Main(string[] args)
        {
            char s1 = char.Parse(Console.ReadLine());
            char s2 = char.Parse(Console.ReadLine());
            char s3 = char.Parse(Console.ReadLine());
            char s4 = char.Parse(Console.ReadLine());
            int s5 = int.Parse(Console.ReadLine());

            int count = 0;

            for (char i = 'A'; i <= s1; i++)
            {
                for (char j = 'a'; j <= s2; j++)
                {
                    for (char k = 'a'; k <= s3; k++)
                    {
                        for (char l = 'a'; l <= s4; l++)
                        {
                            for (int m = 0; m <= s5; m++)
                            {
                                count++;
                            }
                        }
                    }
                }
            }
            Console.WriteLine(count-1);
        }
    }
}