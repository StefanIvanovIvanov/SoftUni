using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_StudentSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    //[Table("StudentTable")]
    public class Student
    {   //[Key]
        public int StudentId { get; set; }

        //[Required]
        [Column("StudentName", Order =3, TypeName="varchar(30)")]
        public string Name { get; set; }

        [Range(1,4)]
        public int Year { get; set; }

        //[NotMapped]
        public string FirstName { get; set; }

        //[NotMapped]
        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime RegisteredOn { get; set; }

        public DateTime? Birthday { get; set; }

        public ICollection<Homework> HomeworkSubmissions { get; set; } = new List<Homework>();

        public ICollection<StudentCourse> CourseEnrollments { get; set; } = new List<StudentCourse>();

        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime LastUpdated { get; set; }
    }
}
