using System;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options)
            : base(options)
        {
        }

        public Context()
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasMany(x => x.ManagerOfProjects)
                .WithOne(x => x.Employee)
                .OnDelete(DeleteBehavior.Cascade);
            //deletes related objects

            modelBuilder.Entity<Employee>()
                .HasMany(x => x.ManagerOfProjects)
                .WithOne(x => x.Employee)
                .OnDelete(DeleteBehavior.Restrict);
            //throws exception

            modelBuilder.Entity<Employee>()
                .HasMany(x => x.ManagerOfProjects)
                .WithOne(x => x.Employee)
                .OnDelete(DeleteBehavior.ClientSetNull);
            //becomes NULL in the code but not the database


            modelBuilder.Entity<Employee>()
                .HasMany(x => x.ManagerOfProjects)
                .WithOne(x => x.Employee)
                .OnDelete(DeleteBehavior.SetNull);
            //becomes NULL

            base.OnModelCreating(modelBuilder);
        }
    }
}
