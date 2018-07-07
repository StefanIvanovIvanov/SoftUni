using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using CodeFirst.POCOs;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst
{
    public class CodeFirstContext : DbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<File> Files { get; set; }
        DbSet<Date> Dates { get; set; }
        private DbSet<DateFile> DatesFiles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Date>().HasMany(x => x.Files);
            modelBuilder.Entity<File>().HasMany(x => x.Dates);
            modelBuilder.Entity<DateFile>().HasKey(x => new {x.DateId, x.FileId});

            base.OnModelCreating(modelBuilder);
        }
    }
}
