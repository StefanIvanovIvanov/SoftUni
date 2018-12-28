using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace _08.AverageGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("input.txt");
            int n = int.Parse(input[0]);
            List<Student>listOfStudents = new List<Student>();
            for (int i = 1; i <=n; i++)
            {
                List<string> newStudent = input[i].Split(new []{' '}).ToList();

                Student student = new Student();

                student.name = newStudent[0];
                student.grades = newStudent.Skip(1).Select(double.Parse).ToList();

                listOfStudents.Add(student);
            }

            List<Student> results = listOfStudents.Where(s => s.averageGrade >= 5.00).OrderBy(s => s.name)
                .ThenByDescending(s => s.averageGrade).ToList();

            foreach (var student in results)
            {
                File.AppendAllText("output.txt", $"{student.name} -> {student.averageGrade:f2}"+Environment.NewLine);
            }
        }
    }

    class Student
    {
        public string name { get; set; }
        public List<double> grades { get; set; }
        public double averageGrade => grades.Average();
    }
    
}
