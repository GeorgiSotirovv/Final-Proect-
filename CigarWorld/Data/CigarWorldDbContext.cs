using CigarWorld.Data.Configuration;
using CigarWorld.Data.Models;
using CigarWorld.Data.Models.ManyToMany;
using CigarWorld.Data.Models.Reviews;
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

        //Items
        public DbSet<Cigar> Cigars { get; set; }
        public DbSet<Ashtray> Ashtrays { get; set; }
        public DbSet<Cigarillo> Cigarillo { get; set; }
        public DbSet<Cutter> Cutters { get; set; }
        public DbSet<Humidor> Humidors { get; set; }
        public DbSet<CigarPocketCase> CigarPocketCases { get; set; }
        public DbSet<Lighter> Lighters { get; set; }

        //Types
        public DbSet<StrengthType> StrengthTypes { get; set; }
        public DbSet<FilterType> FilterTypes { get; set; }
        public DbSet<CutterType> CutterTypes { get; set; }
        public DbSet<AshtrayType> AshtrayTypes { get; set; }

        //Reviews
        public DbSet<AshtrayReview> AshtrayReviews { get; set; }
        public DbSet<CigarilloReview> CigarilloReviews { get; set; }
        public DbSet<CigarReview> CigarReviews { get; set; }
        public DbSet<HumidorReview> HumidorReviews { get; set; }
        public DbSet<CutterReview> CutterReviews { get; set; }
        public DbSet<LighterReview> LighterReviews { get; set; }
        public DbSet<CigarPocketCaseReview> CigarPocketCaseReviews { get; set; }

        //Favorites
        public DbSet<UserAshtray> UserAshtrays { get; set; }
        public DbSet<UserCigar> UserCigars { get; set; }
        public DbSet<UserCigarillo> UserCigarillos { get; set; }
        public DbSet<UserCigarPocketCase> UserCigarPocketCases { get; set; }
        public DbSet<UserCutter> UserCutters { get; set; }
        public DbSet<UserLighter> UserLighters { get; set; }
        public DbSet<UserHumidor> UserHumidors { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserCigar>(ent =>
            {
                ent.HasKey(e => new { e.UserId, e.CigarId });

                ent.Property(e => e.UserId).HasColumnName("UserId");
                ent.Property(e => e.CigarId).HasColumnName("CigarId");
            });

            builder.Entity<UserAshtray>(ent =>
            {
                ent.HasKey(e => new { e.UserId, e.AshtrayId });

                ent.Property(e => e.UserId).HasColumnName("UserId");
                ent.Property(e => e.AshtrayId).HasColumnName("AshtrayId");
            });

            builder.Entity<UserCigarillo>(ent =>
            {
                ent.HasKey(e => new { e.UserId, e.CigarilloId });

                ent.Property(e => e.UserId).HasColumnName("UserId");
                ent.Property(e => e.CigarilloId).HasColumnName("CigarilloId");
            });

            builder.Entity<UserCutter>(ent =>
            {
                ent.HasKey(e => new { e.UserId, e.CutterId });

                ent.Property(e => e.UserId).HasColumnName("UserId");
                ent.Property(e => e.CutterId).HasColumnName("CutterId");
            });

            builder.Entity<UserCigarPocketCase>(ent =>
            {
                ent.HasKey(e => new { e.UserId, e.CigarPocketCaseId });

                ent.Property(e => e.UserId).HasColumnName("UserId");
                ent.Property(e => e.CigarPocketCaseId).HasColumnName("CigarPocketCaseId");
            });

            builder.Entity<UserLighter>(ent =>
            {
                ent.HasKey(e => new { e.UserId, e.LighterId });

                ent.Property(e => e.UserId).HasColumnName("UserId");
                ent.Property(e => e.LighterId).HasColumnName("LighterId");
            });

            builder.Entity<UserHumidor>(ent =>
            {
                ent.HasKey(e => new { e.UserId, e.HumidorId });

                ent.Property(e => e.UserId).HasColumnName("UserId");
                ent.Property(e => e.HumidorId).HasColumnName("HumidorId");
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

            builder.ApplyConfiguration(new CigarilloReviewConfiguration());
            builder.ApplyConfiguration(new CigarReviewConfiguration());
            builder.ApplyConfiguration(new CigarPocketCaseReviewConfiguration());
            builder.ApplyConfiguration(new CutterReviewConfiguration());
            builder.ApplyConfiguration(new HumidorReviewConfiguration());
            builder.ApplyConfiguration(new LighterReviewConfiguration());
            builder.ApplyConfiguration(new AshtrayReviewConfiguration());

            base.OnModelCreating(builder);
        }
    }
}