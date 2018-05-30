using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._.TrophonTheGrumpyCat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> items = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();
            int entryPoint = int.Parse(Console.ReadLine());
            string type = Console.ReadLine();
            string priceRating = Console.ReadLine();

            long left = 0;
            long right = 0;

            //left side
            for (int i = 0; i < entryPoint; i++)
            {
                if (priceRating == "negative" && items[i] < 0)
                {
                    if (type == "cheap" && items[i] < items[entryPoint])
                    {
                        left += items[i];
                    }
                    else if (type == "expensive" && items[i] >= items[entryPoint])
                    {
                        left += items[i];
                    }
                }
                else if (priceRating == "positive" && items[i] > 0)
                {
                    if (type == "cheap" && items[i] < items[entryPoint])
                    {
                        left += items[i];
                    }
                    else if (type == "expensive" && items[i] >= items[entryPoint])
                    {
                        left += items[i];
                    }
                }
                else if (priceRating == "all")
                {
                    if (type == "cheap" && items[i] < items[entryPoint])
                    {
                        left += items[i];
                    }
                    else if (type == "expensive" && items[i] >= items[entryPoint])
                    {
                        left += items[i];
                    }

                }                
            }

            //right side
            for (int i = entryPoint+1; i < items.Count; i++)
            {
                if (priceRating == "negative" && items[i] < 0)
                {
                    if (type == "cheap" && items[i] < items[entryPoint])
                    {
                        right += items[i];
                    }
                    else if (type == "expensive" && items[i] >= items[entryPoint])
                    {
                        right += items[i];
                    }
                }
                else if (priceRating == "positive" && items[i] > 0)
                {
                    if (type == "cheap" && items[i] < items[entryPoint])
                    {
                        right += items[i];
                    }
                    else if (type == "expensive" && items[i] >= items[entryPoint])
                    {
                        right += items[i];
                    }
                }
                else if (priceRating == "all")
                {
                    if (type == "cheap" && items[i] < items[entryPoint])
                    {
                        right += items[i];
                    }
                    else if (type == "expensive" && items[i] >= items[entryPoint])
                    {
                        right += items[i];
                    }
                }
            }
            if (left >= right)
            {
                Console.WriteLine($"Left - {left}");
            }else if (left < right)
            {
                Console.WriteLine($"Right - {right}");
            }
        }
    }
}