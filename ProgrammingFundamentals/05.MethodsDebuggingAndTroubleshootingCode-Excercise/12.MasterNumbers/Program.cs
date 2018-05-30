using System;

namespace _12.MasterNumbers
{
    class Program
    {
            static void Main(string[] args)
            {
                int n = int.Parse(Console.ReadLine());
                for (int i = 1; i <= n; i++)
                {
                    if (isPalindrome(i) == true && divisibleSum(i) == true
                        && haveEven(i) == true)
                    {
                        Console.WriteLine(i);
                    }
                }
            }
            public static bool isPalindrome(int number)
            {
                string str = number.ToString();
                if (str.Length < 4 && str[0] == str[str.Length - 1])
                {
                    return true;
                }
                else if (str.Length < 6 &&
                    (str[0] == str[str.Length - 1] && str[1] == str[str.Length - 2]))
                {
                    return true;
                }
                else if (str.Length < 8 &&
                   (str[0] == str[str.Length - 1] && str[1] == str[str.Length - 2]
                   && str[2] == str[str.Length - 3]))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public static bool divisibleSum(int number)
            {
                string str = number.ToString();
                int sumOfDigits = 0;
                for (int i = 0; i < str.Length; i++)
                {
                    sumOfDigits += int.Parse(str[i].ToString());
                }
                if (sumOfDigits % 7 == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public static bool haveEven(int number)
            {
                string str = number.ToString();
                int evenCounter = 0;
                for (int i = 0; i < str.Length; i++)
                {
                    int currentDigit = int.Parse(str[i].ToString());
                    if (currentDigit % 2 == 0)
                    {
                        evenCounter++;
                    }
                }
                if (evenCounter > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        
    }
}