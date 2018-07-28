using System;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using ProductShop.Models;

namespace ProductShop.Data
{
    public class ProductShopContext : DbContext
    {
        public ProductShopContext()
        {
        }

        public ProductShopContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryProduct> CategoryProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryProduct>().HasKey(x => new {x.CategoryId, x.ProductId});

            modelBuilder.Entity<User>(u =>
            u.HasMany(x => x.ProductsSold)
                .WithOne(x => x.Seller)
                .HasForeignKey(x => x.SellerId));

            modelBuilder.Entity<User>(u =>
            u.HasMany(x => x.ProductsBought)
                .WithOne(x => x.Buyer)
                .HasForeignKey(x => x.BuyerId));
        }
    }
}
