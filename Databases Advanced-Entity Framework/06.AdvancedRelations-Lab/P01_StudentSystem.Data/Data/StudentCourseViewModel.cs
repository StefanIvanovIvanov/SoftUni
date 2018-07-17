using System;
using System.Collections.Generic;
using System.Text;

namespace P01_StudentSystem.Data
{
   public class StudentCourseViewModel
    {
        public StudentCourseViewModel()
        {
            this.CourseNames=new List<string>();
        }

        public string StudentName { get; set; }
        public ICollection<string> CourseNames { get; set; }
    }
}
