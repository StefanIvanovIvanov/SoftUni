using System;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            double n = double.Parse(Console.ReadLine());

            double twoToTwoNonenyNine = 0;
            double threeToThreeNinentyNine = 0;
            double fourToFourNinentyNine = 0;
            double fiveAndAbove = 0;
            double totalGrade = 0;


            for (int i = 1; i <= n; i++)
            {
                double grade = double.Parse(Console.ReadLine());

                if (grade <= 2.99)
                {
                    twoToTwoNonenyNine += 1;
                }
                else if (3 <= grade && grade < 3.99)
                {
                    threeToThreeNinentyNine += 1;
                }
                else if (4 <= grade && grade < 4.99)
                {
                    fourToFourNinentyNine += 1;
                }
                else if (5 <= grade)
                {
                    fiveAndAbove += 1;
                }
                totalGrade = totalGrade + grade;
            }
            double total = twoToTwoNonenyNine + threeToThreeNinentyNine + fourToFourNinentyNine + fiveAndAbove;

            double percentFail = (twoToTwoNonenyNine / n)*100;
            double percentThreeToFour = (threeToThreeNinentyNine / n)*100;
            double fourToFive = (fourToFourNinentyNine / n)*100;
            double aboveFive = (fiveAndAbove / n)*100;

            double averageResult = totalGrade / n;

            Console.WriteLine("Top students: {0:f2}%", aboveFive);
            Console.WriteLine("Between 4.00 and 4.99: {0:f2}%", fourToFive);
            Console.WriteLine("Between 3.00 and 3.99: {0:f2}% ", percentThreeToFour);
            Console.WriteLine("Fail: {0:f2}%", percentFail);
            Console.WriteLine("Average: {0:f2}", averageResult);
        }
    }
}