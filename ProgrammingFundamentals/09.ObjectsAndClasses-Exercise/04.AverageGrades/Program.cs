using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Linq;
using System.Runtime.InteropServices;

namespace _04.AverageGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List < Student > students= new List<Student>();

            for (int i = 1; i <= n; i++)
            {
                string[] input = Console.ReadLine().Split();

                Student student = new Student();

                student.Name = input[0];
                student.Grades = input.Skip(1).Select(double.Parse).ToList();
                students.Add(student);
            }
            List<Student> resultStudents = students.Where(s => s.Average >= 5.00).OrderBy(s => s.Name)
                .ThenByDescending(s => s.Average).ToList();

            foreach (var student in resultStudents)
            {
                Console.WriteLine($"{student.Name} -> {student.Average:F2}");
            }
        }
    }

    class Student
    {
        public string Name { get; set; }
        public List<double> Grades { get; set; }
        public double Average => Grades.Average();
    }
}