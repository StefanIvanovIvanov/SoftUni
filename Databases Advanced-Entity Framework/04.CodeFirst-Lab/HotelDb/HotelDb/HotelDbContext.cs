using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using HotelDb.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelDb
{
    class HotelDbContext : DbContext
    {
        public DbSet<Room> Rooms { get; set; }
        private DbSet<KeyCard> KeyCards { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies(true);
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {//setting RoomKeyCard to have 2 Primary Keys
            modelBuilder.Entity<RoomKeyCard>().HasKey(x => new {x.RoomId, x.KeyCardId});

            modelBuilder.Entity<RoomKeyCard>()
                .HasOne(x => x.Room)
                .WithMany(x => x.RoomKeyCards);

            modelBuilder.Entity<RoomKeyCard>()
                .HasOne(x => x.KeyCard)
                .WithMany(x => x.RoomKeyCards);

            base.OnModelCreating(modelBuilder);
        }

    }
}
