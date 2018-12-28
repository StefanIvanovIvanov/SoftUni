using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace _08.MentorGroup
{
    public class Student
    {
        public string Name { get; set; }
        public List<DateTime> DatesAttended { get; set; }
        public List<string> Comments { get; set; }
    }

    public class Program
    {
        public static void Main()
        {
            var namesAndDates = ReadNamesAndDates();
            var comments = ReadComments(namesAndDates.Keys.ToList());
            var allStudents = GetStudents(namesAndDates, comments);
            PrintStudents(allStudents);
        }

        public static void PrintStudents(List<Student> allStudents)
        {
            foreach (var student in allStudents.OrderBy(st => st.Name))
            {
                var studentName = student.Name;
                var dates = student.DatesAttended.OrderBy(d => d).ToList();
                var studentComments = student.Comments;
                Console.WriteLine($"{studentName}");
                var commentsCount = studentComments.Count;
                if (commentsCount > 0)
                {
                    Console.WriteLine("Comments:");
                    foreach (var comment in studentComments)
                    {
                        Console.WriteLine($"- {comment}");
                    }
                }
                else
                {
                    Console.WriteLine("Comments:");
                }
                Console.WriteLine($"Dates attended:");
                if (dates.Count > 0)
                {
                    foreach (var date in dates)
                    {
                        var day = date.Day;
                        var month = date.Month;
                        var year = date.Year;
                        Console.WriteLine($"-- {day:d2}/{month:d2}/{year:d4}");
                    }
                }
            }
        }

        public static List<Student> GetStudents(Dictionary<string, List<DateTime>> namesAndDates, Dictionary<string, List<string>> comments)
        {
            var studentsList = new List<Student>();
            foreach (var student in namesAndDates)
            {
                var name = student.Key;
                var dates = student.Value;
                var studentComments = new List<string>();
                if (comments.ContainsKey(name))
                {
                    studentComments = comments[name];
                }
                var currentStudent = new Student
                {
                    Name = name,
                    DatesAttended = dates,
                    Comments = studentComments
                };
                studentsList.Add(currentStudent);
            }
            return studentsList;
        }

        private static Dictionary<string, List<string>> ReadComments(List<string> names)
        {
            var line = Console.ReadLine();
            var namesAndComments = new Dictionary<string, List<string>>();
            while (line != "end of comments")
            {
                var tokens = line.Split('-');
                var name = tokens[0];
                var comment = tokens[1];
                if (!names.Contains(name))
                {
                    line = Console.ReadLine();
                    continue;
                }
                if (!namesAndComments.ContainsKey(name))
                {
                    namesAndComments[name] = new List<string>();
                }
                namesAndComments[name].Add(comment);
                line = Console.ReadLine();
            }

            return namesAndComments;
        }

        public static Dictionary<string, List<DateTime>> ReadNamesAndDates()
        {
            var line = Console.ReadLine();
            var namesAndDates = new Dictionary<string, List<DateTime>>();
            while (line != "end of dates")
            {
                var tokens = line.Split(new[] { ' ', ',' });
                var name = tokens[0];
                if (tokens.Length == 1)
                {
                    namesAndDates[name] = new List<DateTime>();
                    line = Console.ReadLine();
                    continue;
                }
                var dates = tokens.Skip(1).Select(a => DateTime.ParseExact(a, "dd/MM/yyyy", CultureInfo.InvariantCulture)).ToList();
                if (!namesAndDates.ContainsKey(name))
                {
                    namesAndDates[name] = new List<DateTime>();
                }
                namesAndDates[name].AddRange(dates);
                line = Console.ReadLine();
            }
            return namesAndDates;
        }
    }
}