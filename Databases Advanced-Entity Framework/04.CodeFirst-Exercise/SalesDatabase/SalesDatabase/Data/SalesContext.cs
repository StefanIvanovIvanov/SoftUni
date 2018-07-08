using System;
using System.Collections.Generic;
using System.Text;
using SalesDatabase.Data;
using SalesDatabase.Data.Models;

namespace SalesDatabase.Data
{
    using SalesDatabase.Data.Models;
    using Microsoft.EntityFrameworkCore;
    public class SalesContext : DbContext
    {
        public SalesContext()
        {
        }
        public SalesContext(DbContextOptions options)
            : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Store> Stores { get; set; }

        public DbSet<Sale> Sales { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(Configuration.ConnectionString);
            }
        }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Store>(
                st =>
                {
                    st.Property(s => s.Name)
                        .IsRequired()
                        .IsUnicode()
                        .HasMaxLength(80);
                });

            builder.Entity<Store>()
                .ToTable("Stores")
                .HasMany(s => s.Sales)
                .WithOne(sl => sl.Store)
                .HasForeignKey(sl => sl.StoreId);


            builder.Entity<Customer>(
                cr =>
                {
                    cr.Property(c => c.Name)
                        .IsRequired()
                        .IsUnicode()
                        .HasMaxLength(100);

                    cr.Property(c => c.Email)
                        .IsUnicode(false)
                        .HasMaxLength(80);
                });

            builder.Entity<Customer>()
                .ToTable("Customers")
                .HasMany(c => c.Sales)
                .WithOne(sl => sl.Customer)
                .HasForeignKey(sl => sl.CustomerId);

            builder.Entity<Product>(
                pr =>
                {
                    pr.Property(p => p.Name)
                        .IsRequired()
                        .IsUnicode()
                        .HasMaxLength(50);
                    
                    pr.Property(p => p.Description)
                    .HasMaxLength(250)
                    .HasDefaultValue("No description");
                });

            builder.Entity<Product>()
                .ToTable("Products")
                .HasMany(p => p.Sales)
                .WithOne(sl => sl.Product)
                .HasForeignKey(sl => sl.ProductId);


            builder.Entity<Sale>(
                sl =>
                {
                    sl.Property(s => s.Date)
                    .HasColumnType("DATETIME2")
                    .HasDefaultValueSql("GETDATE()")
                    ;
                });

            builder.Entity<Sale>()
                .ToTable("Sales");
        }
    }
}