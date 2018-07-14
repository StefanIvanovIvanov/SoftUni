using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Data
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.UserId);

            builder.Property(e => e.Name)
                .IsRequired(false)
                .HasMaxLength(100);

            builder.Property(e => e.Username)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.Name)
                 .IsRequired()
                 .HasMaxLength(25);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(80);


        }
    }
}