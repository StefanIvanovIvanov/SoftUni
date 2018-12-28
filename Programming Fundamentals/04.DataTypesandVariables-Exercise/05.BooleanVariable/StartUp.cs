using System;

namespace _05.BooleanVariable
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            bool check = Convert.ToBoolean(input);

            if (check == true)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }

        }
    }
}