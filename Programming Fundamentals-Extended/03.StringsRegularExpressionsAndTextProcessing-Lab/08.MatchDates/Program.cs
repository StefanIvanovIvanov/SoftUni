using System;
using System.Text.RegularExpressions;

namespace _08.MatchDates
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\b(\d{2})([\/\.\-])([A-Z][a-z][a-z])(\2)(\d{4})\b";
            string input = Console.ReadLine();

            foreach (Match m in Regex.Matches(input, pattern))
            {
                string day = m.Groups[1].Value;
                string month = m.Groups[3].Value;
                string year = m.Groups[5].Value;

                Console.WriteLine($"Day: {day}, Month: {month}, Year: {year}");
            }

        }
    }
}