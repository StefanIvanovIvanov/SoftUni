using System;

namespace _08.CaloriesCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int totalCalories = 0;

            for (int i = 1; i <= n; i++)
            {
                string ingredient = Console.ReadLine();
                ingredient = ingredient.ToLower();

                if (ingredient == "cheese")
                {
                    totalCalories = totalCalories + 500;
                }
                else if (ingredient == "tomato sauce")
                {
                    totalCalories = totalCalories+150;
                }
                else if (ingredient == "salami")
                {
                    totalCalories = totalCalories + 600;
                }
                else if (ingredient == "pepper")
                {
                    totalCalories = totalCalories + 50;
                }
            }
            Console.WriteLine($"Total calories: {totalCalories}");







        }
    }
}