using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data
{
    internal class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Courses");

            builder.HasKey(c => c.CourseId);

            builder.Property(p => p.Name)
                .IsUnicode()
                .HasMaxLength(80);

            builder.Property(p => p.Description)
                .IsRequired(false)
                .IsUnicode();

            builder.Property(p => p.StartDate)
                .HasColumnType("DATETIME2");

            builder.Property(p => p.EndDate)
                .HasColumnType("DATETIME2");
        }
    }
}