﻿using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace P01_StudentSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class StudentCourse
    {      
        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
