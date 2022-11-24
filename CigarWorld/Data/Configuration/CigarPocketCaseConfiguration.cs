using CigarWorld.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CigarWorld.Data.Configuration
{
    internal class CigarPocketCaseConfiguration : IEntityTypeConfiguration<CigarPocketCase>
    {
        public void Configure(EntityTypeBuilder<CigarPocketCase> builder)
        {
            builder.HasData(new CigarPocketCase
            {
                Id = 1,
                Brand = "Visol",
                CountryOfManufacturing = "Germany",
                ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRev3HE7yrOrEkefMQhkif-qti8T5pm9262jQ&usqp=CAU",
                Comment = "Expertly crafted with the small cigar smoker in mind, the premium quality Visol Landon Carbon Fiber Mini Cigar Case allows you toss away your ugly cigarillo boxes and carry up to 4- little stogies in style..",
                MaterialOfManufacture = "Оak",
                Capacity = 4
            });
        }
    }
}
