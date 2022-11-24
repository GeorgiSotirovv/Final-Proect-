using CigarWorld.Data.Configuration;
using CigarWorld.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CigarWorld.Data
{
    public class CigarWorldDbContext : IdentityDbContext<ApplicationUser>
    {
        public CigarWorldDbContext(DbContextOptions<CigarWorldDbContext> options)
            : base(options)
        {

        }

        public DbSet<Cigar> Cigars { get; set; }
        public DbSet<Ashtray> Ashtrays { get; set; }
        public DbSet<Cigarillo> Cigarillos { get; set; }
        public DbSet<Cutter> Cutters { get; set; }
        public DbSet<Humidor> Humidors { get; set; }
        public DbSet<CigarPocketCase> CigarPocketCases { get; set; }
        public DbSet<Lighter> Lighters { get; set; }
        public DbSet<StrengthType> StrengthTypes { get; set; }
        public DbSet<FilterType> FilterTypes { get; set; }
        public DbSet<CutterType> CutterTypes { get; set; }
        public DbSet<AshtrayType> AshtrayTypes { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasKey(x => new
                {
                    x.ApplicationUserId,
                    x.AshtrayId,
                    x.CigarId,
                    x.CigarilloId,
                    x.HumidorId,
                    x.LighterId,
                    x.CigarPocketCaseId,
                    x.CutterId
                });

            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new AshtrayConfiguration());
            builder.ApplyConfiguration(new AshtrayTypeConfiguration());
            builder.ApplyConfiguration(new LighterConfiguration());
            builder.ApplyConfiguration(new CigarConfiguration());
            builder.ApplyConfiguration(new StrengthTypeConfiguration());
            builder.ApplyConfiguration(new HumidorConfiguration());
            builder.ApplyConfiguration(new CigarilloConfiguration());
            builder.ApplyConfiguration(new FilterTypeConfiguration());
            builder.ApplyConfiguration(new CutterConfiguration());
            builder.ApplyConfiguration(new CutterTypeConfiguration());
            builder.ApplyConfiguration(new CigarPocketCaseConfiguration());

            base.OnModelCreating(builder);
        }
    }
}