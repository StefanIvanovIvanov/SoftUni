using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data
{
    internal class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey("StudentId");
            //builder.HasKey(s => s.StudentId);
            
            //Renames the table to Students and the schema to StudentSchema
            builder.ToTable("Students", "StudentSchemea");

            //gives the colum name StudentName and Type VarChat with limit 20 characters
            builder.Property(s => s.Name)
                .HasColumnName("StudentName")
                .HasColumnType("varchar(20)");

            //builder.Property(s => s.Name)
            //    .HasMaxLength(20);

            //builder.Property(s => s.Name)
            //    .HasColumnName("StudentName")
            //    .HasColumnType("varchar")
            //    .HasMaxLength(20);

            builder.Property(s => s.LastUpdated)
                .HasDefaultValueSql("GETUTCDATE()")
                .ValueGeneratedOnAddOrUpdate();
            //or  .HasDefaultValueSql("GETDATE()");

            builder.Property(p => p.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(100);

            builder.Ignore(s => s.FirstName)
                .Ignore(s => s.LastName);

            builder.Property(p => p.PhoneNumber)
                .IsRequired(false)
                .IsUnicode(false)
                .HasColumnType("CHAR(10)");

            builder.Property(p => p.RegisteredOn)
                .HasColumnType("DATETIME2");

            builder.Property(p => p.Birthday)
                .IsRequired(false);

            builder.HasIndex(s => s.Year);
        }
    }
}