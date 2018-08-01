using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace AutoMapping
{
    public class AutoMapperContext : DbContext
    {
        public AutoMapperContext(DbContextOptions options) : base(options)
        {
        }

        public AutoMapperContext()
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Storage> Storages { get; set; }
        public DbSet<ProductStocks> ProductStocks { get; set; }
        public DbSet<ProductDTO> ProductDtos { get; set; }
    }
}
