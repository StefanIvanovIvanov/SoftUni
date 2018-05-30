using System;

namespace RectangleGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int volume = 0;
            int count = 0;

            for (int i = -n; i <= n; i++)
            {
                for (int j = -n; j <= n; j++)
                {
                    for (int k = i+1; k <= n; k++)
                    {
                        for (int l = j+1; l <= n; l++)
                        {
                            volume = Math.Abs(k - i) * Math.Abs(j - l);
                            if (volume >= m)
                            {
                                Console.WriteLine("({0}, {1}) ({2}, {3}) -> {4}", i, j, k, l, volume);
                                count++;
                            }
                        }
                    }
                }
            }
            if (count == 0)
            {
                Console.WriteLine("No");
            }
        }
    }
}