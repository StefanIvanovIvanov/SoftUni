using P01_StudentSystem.Data;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Extensions.Internal;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem
{
    class StartUp
    {
        static void Main(string[] args)
        {
            using (StudentSystemContext context = new StudentSystemContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                Student st = new Student();

                //anonymous select
                var studentsWithCourse = context.Students.Select(
                    x => new
                    {
                        StudentName = x.Name,
                        CourseCount = x.CourseEnrollments.Count()
                    });


                var students = context.Students
                    .Include(x => x.CourseEnrollments)
                    .ToList();

                //ThenInclude can be used multiple times
                var studentsNew = context.Students
                    .Include(x => x.CourseEnrollments)
                    .ThenInclude(x=>x.Course)
                    .ToList();

                var newStudents = context.Students.GroupBy(s => s.Name)
                    .ToList();

            }
        }
    }
}
