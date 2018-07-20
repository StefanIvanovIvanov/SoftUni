using System;
using AutoMapping.Models;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace AutoMapping.Data
{
    public class AutoMappingContext : DbContext
    {
        public AutoMappingContext()
        {
        }

        public AutoMappingContext(DbContextOptions options) 
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
