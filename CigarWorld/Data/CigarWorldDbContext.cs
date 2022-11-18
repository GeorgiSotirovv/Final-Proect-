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




            builder
                .Entity<Cigar>()
                .HasData(new Cigar()
                {
                    Id = 1,
                    Brand = "Cohiba",
                    Format = "Vitola",
                    Length = 119,
                    Ring = 52,
                    SmokingDuration = 90,
                    CountryOfManufacturing = "Cuba",
                    Comment = "This cigar is very unice. The taste, smoke from she and the flavor make the cigar a very special.",
                    ImageUrl = "https://kalimancaribe.com/images/thumbnails/650/366/detailed/5/COHIBA_BEHIKE_BHK_52.jpg",
                    StrengthId = 1
                });

            builder
                .Entity<StrengthType>()
                .HasData(new StrengthType()
                {
                    Id = 1,
                    Name = "Mild"
                },
                new StrengthType()
                {
                    Id = 2,
                    Name = "Medium"
                },
                new StrengthType()
                {
                    Id = 3,
                    Name = "Full"
                });

            builder
                .Entity<Humidor>()
                .HasData(new Humidor()
                {
                    Id = 1,
                    Brand = "The Hampton",
                    ImageUrl = "https://www.cigarhumidors-online.com/media/catalog/product/cache/1/image/430x295/9df78eab33525d08d6e5fb8d27136e95/h/m/hmptnblu6.jpg",
                    Height = 20,
                    Length = 20,
                    Weight = 5,
                    Capacity = 50,
                    MaterialOfManufacture = "Оak",
                    CountryOfManufacturing = "Cuba",
                    Comment = "This remarkable black lacquer piece features a diamond pattern bonded leather inlay w/ red accent stitching."
                });

            builder
                .Entity<Ashtray>()
                .HasData(new Ashtray()
                {
                    Id = 1,
                    Brand = "Lubinski",
                    AshtrayId = 1,
                    CountryOfManufacturing = "China",
                    ImageUrl = "https://m.media-amazon.com/images/I/51xDDJtDbBL._AC_SY1000_.jpg",
                    Comment = "Really nice and colorful ashtray."
                });

            builder
                .Entity<AshtrayType>()
                .HasData(new AshtrayType
                {
                    
                    Id = 1,
                    Name = "For cigars"
                },
                new AshtrayType()
                {
                    Id = 2,
                    Name = "For Cigarillos"
                
                });

            builder
                .Entity<Cigarillo>()
                .HasData(new Cigarillo
                {
                    Id = 1,
                    Brand = "Clubmaster",
                    CountryOfManufacturing = "Germany",
                    ImageUrl = "https://i.colnect.net/f/4259/015/Clubmaster-Mini.jpg",
                    Comment = "This Cigarillos have a very nice taste and nice flavor.",
                    FiterId = 1,
                });

            builder
                .Entity<CigarPocketCase>()
                .HasData(new CigarPocketCase
                {
                    Id = 1,
                    Brand = "Visol",
                    CountryOfManufacturing = "Germany",
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRev3HE7yrOrEkefMQhkif-qti8T5pm9262jQ&usqp=CAU",
                    Comment = "Expertly crafted with the small cigar smoker in mind, the premium quality Visol Landon Carbon Fiber Mini Cigar Case allows you toss away your ugly cigarillo boxes and carry up to 4- little stogies in style..",
                    MaterialOfManufacture = "Оak",
                    Capacity = 4
                });

            builder
                .Entity<Cutter>()
                .HasData(new Cutter 
                {
                    Id = 1,
                    Brand = "Cohiba",
                    ImageUrl = "https://mikescigars.com/media/catalog/product/cache/0fe343e181b5504db207ac8c729e73b7/h/t/Cohiba-Cutter-each.jpg",
                    CountryOfManufacturing = "Chuba",
                    TypeId = 1,
                    Comment = "Really nice and sharp cutter."
                });

            builder.
                Entity<CutterType>()
               .HasData(new CutterType
               {
                  Id = 1,
                  Name = "Guillotine"
               },
               new CutterType()
               {
                  Id = 2,
                  Name = "V-Cut"
               },
               new CutterType()
               {
                  Id = 3,
                  Name = "Point"
               });

            builder
               .Entity<FilterType>()
               .HasData(new FilterType
               {
                  Id = 1,
                  Name = "Standard"
               },
               new FilterType()
               {
                  Id = 2,
                  Name = "Cherry"
               },
               new FilterType()
               {
                  Id = 3,
                  Name = "Mint"
               },
               new FilterType()
               {
                  Id = 4,
                  Name = "Vanila"
               },
               new FilterType()
               {
                   Id = 5,
                   Name = "Other"
               });

            builder
               .Entity<Lighter>()
               .HasData(new Lighter 
               {
                   Id= 1,
                   Brand = "Cohiba",
                   CountryOfManufacturing = "Cuba",
                   ImageUrl = "https://lacasadelhabano-thehague.com/wp-content/uploads/2020/10/briquet-ligne-2-cohiba-016110-01.png",
                   Comment = "Very nice lighter."
               });

            base.OnModelCreating(builder);
        }
    }
}