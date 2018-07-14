using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Data
{
    internal class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasKey(e => e.TeamId);

            builder.Property(e => e.LogoUrl)
                .IsUnicode(false);

            builder.Property(e => e.Initials)
                .IsRequired()
                .HasColumnType("NCHAR(3)");

            builder.HasOne(t => t.Town)
                .WithMany(tw => tw.Teams)
                .HasForeignKey(t => t.TownId);

            builder.HasOne(t => t.PrimaryKitColor)
                .WithMany(c => c.PrimaryKitTeams)
                .HasForeignKey(t => t.PrimaryKitColorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.SecondaryKitColor)
               .WithMany(c => c.SecondaryKitTeams)
               .HasForeignKey(t => t.SecondaryKitColorId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}