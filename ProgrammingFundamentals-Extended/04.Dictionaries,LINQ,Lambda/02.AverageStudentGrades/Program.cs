using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.AverageStudentGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> students = new Dictionary<string, List<double>>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string name = input[0];
                double grade = double.Parse(input[1]);

                if (students.ContainsKey(name))
                {
                    students[name].Add(grade);
                }
                else
                {
                    students.Add(name, new List<double>());
                    students[name].Add(grade);
                }
            }
            foreach (KeyValuePair<string, List<double>> s in students)
            {
                Console.Write($"{s.Key} -> ");
                foreach (double d in s.Value)
                {
                    Console.Write($"{d:f2} ");
                }
                Console.WriteLine($"(avg: {s.Value.Average():f2})");
            }
        }
    }
}