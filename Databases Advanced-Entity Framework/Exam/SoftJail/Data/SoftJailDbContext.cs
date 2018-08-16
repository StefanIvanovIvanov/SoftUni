using System.Security.Cryptography.X509Certificates;
using SoftJail.Data.Models;

namespace SoftJail.Data
{
	using Microsoft.EntityFrameworkCore;

	public class SoftJailDbContext : DbContext
	{
		public SoftJailDbContext()
		{
		}

		public SoftJailDbContext(DbContextOptions options)
			: base(options)
		{
		}

        public DbSet<Prisoner> Prisoners { get; set; }
	    public DbSet<OfficerPrisoner> OfficersPrisoners { get; set; }
	    public DbSet<Officer> Officers { get; set; }
	    public DbSet<Mail> Mails { get; set; }
	    public DbSet<Department> Departments { get; set; }
	    public DbSet<Cell> Cells { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
			   // optionsBuilder.UseLazyLoadingProxies(true);

				optionsBuilder
					.UseSqlServer(Configuration.ConnectionString);
			}
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
		    builder.Entity<OfficerPrisoner>()
		        .HasKey(x => new {x.OfficerId, x.PrisonerId});

		    builder.Entity<Prisoner>()
		        .HasMany(x => x.PrisonerOfficers)
		        .WithOne(x => x.Prisoner)
		        .HasForeignKey(x => x.PrisonerId);
		       // .OnDelete(DeleteBehavior.Restrict);

		    builder.Entity<Officer>()
		        .HasMany(x => x.OfficerPrisoners)
		        .WithOne(x => x.Officer)
		        .HasForeignKey(x => x.OfficerId);
             //   .OnDelete(DeleteBehavior.Restrict);

		    builder.Entity<Prisoner>()
		        .HasMany(x => x.Mails)
		        .WithOne(x => x.Prisoner)
		        .HasForeignKey(x => x.PrisonerId);
		    //    .OnDelete(DeleteBehavior.Restrict);

		    builder.Entity<Cell>()
		        .HasMany(x => x.Prisoners)
		        .WithOne(x => x.Cell)
		        .HasForeignKey(x => x.CellId);
		    //    .OnDelete(DeleteBehavior.Restrict);

		    builder.Entity<Department>()
		        .HasMany(x => x.Cells)
		        .WithOne(x => x.Department)
		        .HasForeignKey(x => x.DepartmentId);
            //    .OnDelete(DeleteBehavior.Restrict);
		}
	}
}