using System;

namespace StupidPasswordGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var l = int.Parse(Console.ReadLine());

            for (var s1 = 1; s1 <= n; s1++)
            {
                for (var s2 = 1; s2 <= n; s2++)
                {
                    for (var s3 = 'a'; s3<'a'+l; s3++)
                    {
                        for (var s4 = 'a'; s4 < 'a' + l; s4++)
                        {
                            for (var s5 = Math.Max(s1, s2) + 1; s5 <= n; s5++)
                            {
                                Console.Write("{0}{1}{2}{3}{4} ", s1, s2, s3, s4, s5);
                            }
                        }
                    }
                }
            }


        }
    }
}